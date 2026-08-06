import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
const BASE_URL = "http://localhost:5115";

export default function ConfigurePage() {
    const token = sessionStorage.getItem("token");

    const modelId = sessionStorage.getItem("modelId");
    const [components, setComponents] = useState([]);
    const [vehicle, setVehicle] = useState(null);
    const [alternatives, setAlternatives] = useState({});
    const [selectedAlternatives, setSelectedAlternatives] = useState({});
    const [activeTab, setActiveTab] = useState("standard");
    const quantity = Number(sessionStorage.getItem("quantity"));
    const username = sessionStorage.getItem("username");
    const navigate = useNavigate();
    const [finalPrice, setFinalPrice] = useState(0);
        const loadAlternatives = async (componentId) => {

        const res = await fetch(
            `${BASE_URL}/api/configurations/${modelId}/components/${componentId}/alternatives`,{
             
    headers: {
        Authorization: `Bearer ${token}`
    }
     } );

        const data = await res.json();
        console.log("In load alternatives" + JSON.stringify(data, null, 2));
        console.log("Component :", componentId);
        console.log("Alternatives :", data);
        console.log("FIRST ALT =", data[0]);
        console.log(JSON.stringify(alternatives[3], null, 2));
        setAlternatives(prev => ({
            ...prev,
            [componentId]: data
        }));
    }

    const formatPrice = (price) =>
        Number(price).toLocaleString("en-IN");
    useEffect(() => {

        fetch(`${BASE_URL}/api/configurations/${modelId}`, {
    headers: {
        Authorization: `Bearer ${token}`
    }
    })
            .then(res => res.json())
            .then(data => {

                setComponents(data);

                data.forEach(component => {

                    if (component.configurable === "Y") {

                        loadAlternatives(component.componentId);

                    }

                });

            });

 fetch(`${BASE_URL}/api/default-config/${modelId}`, {
    headers: {
        Authorization: `Bearer ${token}`
    }
})
.then(res => res.json())
.then(data => {
    setVehicle(data.vehicle);
    setFinalPrice(data.vehicle.basePrice);
});},[]);
    const handleConfirmOrder = () => {
        console.log("Selected Alternatives =", selectedAlternatives);

        const selectedComponents = [];

        Object.keys(selectedAlternatives).forEach(componentId => {

            const selectedValue = selectedAlternatives[componentId];

            if (selectedValue) {

                const altId = Number(selectedValue);

                const alt = (alternatives[componentId] || []).find(
                    a => a.componentId === altId
                );

                selectedComponents.push({

                    componentId: Number(componentId),
                    alternateComponentId: altId,
                    deltaPrice: alt ? alt.deltaPrice : 0

                });

            }

        });
        console.log(alternatives);
        const request = {

            userId: Number(sessionStorage.getItem("userId")),
            modelId: Number(modelId),
            quantity: quantity,
            totalAmount: subTotal,
            tax: gst,
            finalAmount: grandTotal,
            selectedComponents: selectedComponents

        };
        console.log(JSON.stringify(request, null, 2));
        console.log("Invoice Request =", request);
        fetch("http://localhost:5115/api/invoice/generate", {

            method: "POST",

            headers: {
                "Content-Type": "application/json",

                Authorization: `Bearer ${token}`

            },

            body: JSON.stringify(request)

        })
            .then(async (res) => {

                console.log("Status =", res.status);

                const data = await res.json();

                console.log("Complete Response =", data);

                if (!res.ok) {
                    throw new Error("Invoice generation failed");
                }

                navigate("/invoice/" + data.invoiceId);
            })
            .catch(err => console.log(err));
    };
    const core = components.filter(c => c.componentType === "C");
    const standard = components.filter(c => c.componentType === "S");
    const interior = components.filter(c => c.componentType === "I");
    const exterior = components.filter(c => c.componentType === "E");

    if (!vehicle) {

        return <h2>Loading...</h2>;

    }
    function calculatePrice(selected) {

        let price = vehicle.basePrice;

        Object.keys(selected).forEach(componentId => {

            const altId = Number(selected[componentId]);

            const alt = (alternatives[componentId] || []).find(
                a => a.componentId === altId
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
            <h5 className="fw-bold">
                Welcome, {username} Please Configure your vehicle
            </h5>

            <h2>Configure Vehicle</h2>

            <hr />


            <p><strong>Model :</strong> {vehicle.modelName}</p>

            <p><strong>Manufacturer :</strong> {vehicle.manufacturer}</p>

            <p><strong>Segment :</strong> {vehicle.segment}</p>

            <p><strong>Base Price :</strong> ₹{formatPrice(vehicle.basePrice)}</p>

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


            <hr />

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
                                    <option value="">Default</option>

                                    {(alternatives[component.componentId] || []).map(alt => (

                                        <option
                                            key={alt.altId}
                                            value={alt.componentId}
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
                                    <option value="">Default</option>

                                    {(alternatives[component.componentId] || []).map(alt => (

                                        <option
                                            key={alt.altId}
                                            value={alt.componentId}
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
                                    <option value="">Default</option>

                                    {(alternatives[component.componentId] || []).map(alt => (

                                        <option
                                            key={alt.altId}
                                            value={alt.componentId}
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
                    onClick={handleConfirmOrder}
                >
                    Confirm Order
                </button>

            </div>

            <hr />
            <h4>Price Summary</h4>

            <p>
                <strong>Configured Vehicle Price :</strong> ₹{formatPrice(finalPrice)}
            </p>

            <p>
                <strong>Subtotal ({quantity} Qty) :</strong> ₹{formatPrice(subTotal)}
            </p>

            <p>
                <strong>GST (10%) :</strong> ₹{formatPrice(gst)}
            </p>

            <h3>
                Grand Total : ₹{formatPrice(grandTotal)}
            </h3>
        </div>

    );

}