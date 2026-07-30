import { useEffect, useState } from "react";

const BASE_URL = "http://localhost:8080";

export default function ConfigurePage() {

    const modelId = sessionStorage.getItem("modelId");
    const [components, setComponents] = useState([]);
    const [vehicle, setVehicle] = useState(null);
const [alternatives, setAlternatives] = useState({});
const [selectedAlternatives, setSelectedAlternatives] = useState({});
const [activeTab, setActiveTab] = useState("standard");
const quantity = Number(sessionStorage.getItem("quantity"));

const [finalPrice, setFinalPrice] = useState(0);
useEffect(() => {

    fetch(`${BASE_URL}/api/configurations/${modelId}`)
        .then(res => res.json())
        .then(data => {

            setComponents(data);

            data.forEach(component => {

                if (component.configurable === "Y") {

                    loadAlternatives(component.componentId);

                }

            });

        });

    fetch(`${BASE_URL}/api/default-config/${modelId}`)
        .then(res => res.json())
        .then(data => {

            setVehicle(data.vehicle);
setFinalPrice(data.vehicle.basePrice);
        });

}, []);
    const core = components.filter(c => c.componentType === "C");
    const standard = components.filter(c => c.componentType === "S");
    const interior = components.filter(c => c.componentType === "I");
    const exterior = components.filter(c => c.componentType === "E");
const loadAlternatives = async (componentId) => {

    const res = await fetch(
        `${BASE_URL}/api/configurations/${modelId}/components/${componentId}/alternatives`
    );

    const data = await res.json();

    console.log("Component :", componentId);
    console.log("Alternatives :", data);

    setAlternatives(prev => ({
        ...prev,
        [componentId]: data
    }));
}

if (!vehicle) {

    return <h2>Loading...</h2>;

}

function calculatePrice(selected) {

    let price = vehicle.basePrice;

    Object.keys(selected).forEach(componentId => {

        const altId = Number(selected[componentId]);

        const alt = (alternatives[componentId] || []).find(
            a => a.altId === altId
        );

        if (alt) {

            price += alt.deltaPrice;

        }

    });

    setFinalPrice(price);

}
const subTotal = finalPrice * quantity;
const gst = subTotal * 0.10;
const grandTotal = subTotal + gst;
    return (

        <div className="container mt-4">

            <h2>Configure Vehicle</h2>

            <hr />


<p><strong>Model :</strong> {vehicle.modelName}</p>

<p><strong>Manufacturer :</strong> {vehicle.manufacturer}</p>

<p><strong>Segment :</strong> {vehicle.segment}</p>

<p><strong>Base Price :</strong> ₹{vehicle.basePrice}</p>

<p><strong>Quantity :</strong> {sessionStorage.getItem("quantity")}</p>
<img
    src={`${BASE_URL}/${vehicle.image}`}
    alt={vehicle.modelName}
    width="300"
/>
<hr />
            <h4>Core Components</h4>

            <ul>
                {
                    core.map(c => (
                        <li key={c.componentId}>
                            {c.componentName}
                        </li>
                    ))
                }
            </ul>


<hr/>

{
    activeTab === "standard" &&
    standard.map(component => (
        <div key={component.componentId} style={{ marginBottom: "15px" }}>

            <label style={{ width: "180px" }}>
                {component.componentName}
            </label>

            {
                component.configurable === "Y" ? (

                    <select
                        value={selectedAlternatives[component.componentId] || ""}
                       onChange={(e) => {

    const updated = {

        ...selectedAlternatives,
        [component.componentId]: e.target.value

    };

    setSelectedAlternatives(updated);

    calculatePrice(updated);

}}
                    >
                        <option value="">Select</option>

                        {(alternatives[component.componentId] || []).map(alt => (

                            <option
                                key={alt.altId}
                                value={alt.altId}
                            >
                                {alt.componentName}
                            </option>

                        ))}

                    </select>

                ) : (

                    <span>Standard</span>

                )
            }

        </div>
    ))
}

{
    activeTab === "interior" &&
    interior.map(component => (
        <div key={component.componentId} style={{ marginBottom: "15px" }}>

            <label style={{ width: "180px" }}>
                {component.componentName}
            </label>

            {
                component.configurable === "Y" ? (

                    <select
                        value={selectedAlternatives[component.componentId] || ""}
                  onChange={(e) => {

    const updated = {

        ...selectedAlternatives,
        [component.componentId]: e.target.value

    };

    setSelectedAlternatives(updated);

    calculatePrice(updated);

}}
                    >
                        <option value="">Select</option>

                        {(alternatives[component.componentId] || []).map(alt => (

                            <option
                                key={alt.altId}
                                value={alt.altId}
                            >
                                {alt.componentName}
                            </option>

                        ))}

                    </select>

                ) : (

                    <span>Standard</span>

                )
            }

        </div>
    ))
}

{
    activeTab === "exterior" &&
    exterior.map(component => (
        <div key={component.componentId} style={{ marginBottom: "15px" }}>

            <label style={{ width: "180px" }}>
                {component.componentName}
            </label>

            {
                component.configurable === "Y" ? (

                    <select
                        value={selectedAlternatives[component.componentId] || ""}
                   onChange={(e) => {

    const updated = {

        ...selectedAlternatives,
        [component.componentId]: e.target.value

    };

    setSelectedAlternatives(updated);

    calculatePrice(updated);

}}
                    >
                        <option value="">Select</option>

                        {(alternatives[component.componentId] || []).map(alt => (

                            <option
                                key={alt.altId}
                                value={alt.altId}
                            >
                                {alt.componentName}
                            </option>

                        ))}

                    </select>

                ) : (

                    <span>Standard</span>

                )
            }

        </div>
    ))
}

<div className="mt-4">

    <button
        className="btn btn-primary me-2"
        onClick={() => setActiveTab("standard")}
    >
        Std. Features
    </button>

    <button
        className="btn btn-secondary me-2"
        onClick={() => setActiveTab("interior")}
    >
        Interior
    </button>

    <button
        className="btn btn-secondary me-2"
        onClick={() => setActiveTab("exterior")}
    >
        Exterior
    </button>

    <button
        className="btn btn-success"
    >
        Confirm Order
    </button>

</div>

<hr/>
<h4>Price Summary</h4>

<p>
    <strong>Configured Vehicle Price :</strong> ₹{finalPrice}
</p>

<p>
    <strong>Subtotal ({quantity} Qty) :</strong> ₹{subTotal}
</p>

<p>
    <strong>GST (10%) :</strong> ₹{gst}
</p>

<h3>
    Grand Total : ₹{grandTotal}
</h3>
        </div>

    );

}