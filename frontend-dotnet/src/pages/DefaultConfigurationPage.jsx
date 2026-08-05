import { useLocation } from "react-router-dom";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
function DefaultConfigurationPage(){
const navigate = useNavigate();

    const modelId = sessionStorage.getItem("modelId");
    const quantity = sessionStorage.getItem("quantity");
    const username = sessionStorage.getItem("username");

const [configuration, setConfiguration] = useState(null);
const formatPrice = (price) =>
    Number(price).toLocaleString("en-IN");
const handleConfirmOrder = () => {

    const request = {

        userId: Number(sessionStorage.getItem("userId")),
        modelId: Number(modelId),
        quantity: qty,
        totalAmount: totalPrice,
        tax: gst,
        finalAmount: grandTotal,

        // Default configuration hai, isliye koi alternate component nahi
        selectedComponents: []

    };

    fetch("http://localhost:3306/api/invoice/generate", {

        method: "POST",

        headers: {
            "Content-Type": "application/json"
        },

        body: JSON.stringify(request)

    })
    .then(res => {

        if (!res.ok) {

            throw new Error("Failed to generate invoice");

        }

        return res.json();

    })
    .then(data => {

        alert("Invoice Generated Successfully");

        //console.log(data);
 navigate(`/invoice/${data.invoiceId}`);
       
    })
    .catch(err => {

        alert(err.message);

    });

};
    useEffect(()=>{


        if(modelId){

            fetch(
              `http://localhost:3306/api/default-config/${modelId}`
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
    <h5 className="fw-bold">
                Welcome, {username} Please Configure your vehicle 
            </h5>

  

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
                ₹{formatPrice(vehicle.basePrice)}
            </p>

            <p>
                <strong>Quantity :</strong>{" "}
                {quantity}
            </p>
<p>
    <strong>Total Price :</strong> ₹{formatPrice(totalPrice)}
</p>

<p>
    <strong>GST (10%) :</strong> ₹{formatPrice(gst)}
</p>

<h4>
    Grand Total : ₹{formatPrice(grandTotal)}
</h4>
        </div>

        <div className="vehicle-image">

            <img
                src={`http://localhost:3306/${vehicle.image}`}
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
        className="btn btn-primary me-3"
        onClick={() => navigate("/configure")}
    >
        Configure
    </button>

    <button
        className="btn btn-success"
        onClick={handleConfirmOrder}
    >
        Confirm Order
    </button>

</div>

</div>

);
}


export default DefaultConfigurationPage;