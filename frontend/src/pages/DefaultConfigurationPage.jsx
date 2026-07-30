import { useLocation } from "react-router-dom";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
function DefaultConfigurationPage(){
const navigate = useNavigate();

    const modelId = sessionStorage.getItem("modelId");
    const quantity = sessionStorage.getItem("quantity");

const [configuration, setConfiguration] = useState(null);


    useEffect(()=>{


        if(modelId){

            fetch(
              `http://localhost:8080/api/default-config/${modelId}`
            )
            .then(res=>res.json())
            .then(data=>{

                setConfiguration(data);

            });

        }


    },[modelId]);


if (!configuration) {
    return <h2>Loading...</h2>;
}

const vehicle = configuration.vehicle;

const standard = configuration.components.filter(
    item => item.componentType === "C" || item.componentType === "S"
);

const interior = configuration.components.filter(
    item => item.componentType === "I"
);

const exterior = configuration.components.filter(
    item => item.componentType === "E"
);

    // Taking vehicle details from first record
const basePrice = vehicle.basePrice;

const qty = Number(quantity);

const totalPrice = basePrice * qty;

const gst = totalPrice * 0.10;

const grandTotal = totalPrice + gst;
  return (

<div className="container">

    <h1>Default Configuration</h1>

    <div className="vehicle-container">

        <div className="vehicle-info">

            <h2>{vehicle.modelName}</h2>

            <p>
                <strong>Manufacturer :</strong>{" "}
                {vehicle.manufacturer}
            </p>

            <p>
                <strong>Segment :</strong>{" "}
                {vehicle.segment}
            </p>

            <p>
                <strong>Base Price :</strong>{" "}
                ₹{vehicle.basePrice}
            </p>

            <p>
                <strong>Quantity :</strong>{" "}
                {quantity}
            </p>
<p>
    <strong>Total Price :</strong> ₹{totalPrice}
</p>

<p>
    <strong>GST (10%) :</strong> ₹{gst}
</p>

<h4>
    Grand Total : ₹{grandTotal}
</h4>
        </div>

        <div className="vehicle-image">

            <img
                src={`http://localhost:8080/${vehicle.image}`}
                alt={vehicle.modelName}
                width="350"
            />

        </div>

    </div>

    <hr/>

    <h2>Standard Features</h2>

    {
        standard.map(item => (

            <div key={item.configId}>

                {item.componentName}

            </div>

        ))
    }

    <hr/>

    <h2>Interior Features</h2>

    {
        interior.map(item => (

            <div key={item.configId}>

                {item.componentName}

            </div>

        ))
    }

    <hr/>

    <h2>Exterior Features</h2>

    {
        exterior.map(item => (

            <div key={item.configId}>

                {item.componentName}

            </div>

        ))
    }

    <div className="text-center mt-4">

        <button
            className="btn btn-primary"
            onClick={() => navigate("/configure")}
        >
            Configure
        </button>

    </div>

</div>

);
}


export default DefaultConfigurationPage;