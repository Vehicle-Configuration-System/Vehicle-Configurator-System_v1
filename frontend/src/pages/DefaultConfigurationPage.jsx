import { useLocation } from "react-router-dom";
import { useEffect, useState } from "react";


function DefaultConfigurationPage(){


    const modelId = sessionStorage.getItem("modelId");


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



    // Taking vehicle details from first record

    const vehicle = configuration.vehicle;



    return (

        <div>


            <h1>
                Default Configuration
            </h1>



            <img
              src={`http://localhost:8080/${vehicle.image}`}
              alt={vehicle.modelName}
              width="400"
            />



            <h2>
                {vehicle.modelName}
            </h2>


            <h3>
                Manufacturer :
                {vehicle.manufacturer.manufacturerName}
            </h3>


            <h3>
                Segment :
                {vehicle.segment.segmentName}
            </h3>


            <h3>
                Base Price :
                ₹{vehicle.basePrice}
            </h3>



            <hr/>


            <h2>
                Components
            </h2>


          {configuration.components.map((item) => (

    <div key={item.configId}>

        <h3>{item.componentName}</h3>

        <p>
            Type : {item.componentType}
        </p>

        <p>
            {item.configurable === "Y"
                ? "Customizable"
                : "Fixed"}
        </p>

    </div>

))}


        </div>

    );


}


export default DefaultConfigurationPage;