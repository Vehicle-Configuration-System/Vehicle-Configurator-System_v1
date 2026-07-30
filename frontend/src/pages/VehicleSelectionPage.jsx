import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

function VehicleSelectionPage() {

    const [segments, setSegments] = useState([]);
    const [selectedSegment, setSelectedSegment] = useState("");
const [quantity, setQuantity] = useState("");
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");
    const [manufacturers, setManufacturers] = useState([]);
    const [selectedManufacturer, setSelectedManufacturer] = useState("");
    const [models, setModels] = useState([]);
    const [selectedModel, setSelectedModel] = useState("");
    const [minimumQuantity, setMinimumQuantity] = useState(1);
    const selectedVehicle = models.find(
    model => model.modelId == selectedModel
);
    useEffect(() => {

        fetch("http://localhost:8080/segment")
            .then((response) => {

                if (!response.ok) {
                    throw new Error("Failed to fetch segments");
                }

                return response.json();

            })
            .then((data) => {

                setSegments(data);
                setLoading(false);

            })
            .catch((err) => {

                console.log(err);
                setError("Unable to load segments.");
                setLoading(false);

            });

    }, []);
async function loadManufacturers(segmentId) {

    try {

        const response = await fetch(
            "http://localhost:8080/manufacturer/segment/" + segmentId
        );

        if (!response.ok) {

            throw new Error("Failed to fetch manufacturers");

        }

        const data = await response.json();

        setManufacturers(data);

    }
    catch (err) {

        console.log(err);

    }


}

async function loadModels(manufacturerId,segmentId) {

    try {

        const response = await fetch(
    `http://localhost:8080/model/manufacturer/${manufacturerId}/segment/${segmentId}`
        );

        if (!response.ok) {

            throw new Error("Failed to fetch models");

        }

        const data = await response.json();

        setModels(data);

    }
    catch (err) {

        console.log(err);

    }

}

const navigate = useNavigate();
function handleNext() {

    if (selectedSegment === "") {

        alert("Please select a Segment");

        return;

    }

    if (selectedManufacturer === "") {

        alert("Please select a Manufacturer");

        return;

    }

    if (selectedModel === "") {

        alert("Please select a Model");

        return;

    }

    if (quantity === "") {

        alert("Please enter Quantity");

        return;

    }

    sessionStorage.setItem("segmentId", selectedSegment);

    sessionStorage.setItem("manufacturerId", selectedManufacturer);

    sessionStorage.setItem("modelId", selectedModel);

    sessionStorage.setItem("quantity", quantity);

    navigate("/default-config");

}
    return (

        <div className="container mt-5">

            <div className="card shadow">

                <div className="card-header bg-primary text-white">

                    <h3>Vehicle Configurator</h3>

                </div>

                <div className="card-body">

                    {loading &&

                        <div className="alert alert-info">
                            Loading Segments...
                        </div>

                    }

                    {error &&

                        <div className="alert alert-danger">
                            {error}
                        </div>

                    }

                    <div className="mb-3">

                        <label className="form-label">

                            Select Segment

                        </label>

                        <select

                            className="form-select"

                            value={selectedSegment}

onChange={(e) => {

    const segmentId = e.target.value;

    setSelectedSegment(segmentId);

    setSelectedManufacturer("");

    setManufacturers([]);

    if (segmentId !== "") {

        loadManufacturers(segmentId);

    }

}}
                        >

                            <option value="">
                                Select Segment
                            </option>

                            {
                               segments.map((segment) => (

    <option
        key={segment.segmentId}
        value={segment.segmentId}
    >
        {segment.segmentName}
    </option>

))
                            }

                        </select>

                    </div>

<div className="mb-3">

    <label className="form-label">

        Manufacturer

    </label>

    <select

        className="form-select"

        value={selectedManufacturer}

        onChange={(e) => {

    const manufacturerId = e.target.value;

    setSelectedManufacturer(manufacturerId);

    setSelectedModel("");

    setModels([]);

    if (manufacturerId !== "") {

        loadModels(manufacturerId,selectedSegment);

    }

}}

        disabled={selectedSegment === ""}

    >

        <option value="">

            Select Manufacturer

        </option>

        {

            manufacturers.map((manufacturer) => (

                <option

                    key={manufacturer.manufacturerId}

                    value={manufacturer.manufacturerId}

                >

                    {manufacturer.manufacturerName}

                </option>

            ))

        }

    </select>

</div>

<div className="mb-3">

    <label className="form-label">

        Model

    </label>

    <select

        className="form-select"

        value={selectedModel}

       onChange={(e) => {

    const modelId = e.target.value;

    setSelectedModel(modelId);

    const vehicle = models.find(
        model => model.modelId == modelId
    );

    if(vehicle){

        setMinimumQuantity(vehicle.minimumQuantity);

        setQuantity(vehicle.minimumQuantity);

    }

}}

        disabled={selectedManufacturer === ""}

    >

        <option value="">

            Select Model

        </option>

        {

            models.map((model) => (

                <option

                    key={model.modelId}

                    value={model.modelId}

                >

                    {model.modelName}

                </option>

            ))

        }

    </select>

</div>

<div className="mb-3">

    <label className="form-label">

        Quantity

    </label>

    <input

        type="number"

        className="form-control"

        value={quantity}

        min={minimumQuantity}

        onChange={(e)=>setQuantity(e.target.value)}

        disabled={selectedModel === ""}

    />

    {

        selectedModel &&

        <small className="text-muted">

            Minimum Order Quantity : {minimumQuantity}

        </small>

    }

</div>
<div className="text-center mt-4">

    <button

        className="btn btn-primary"

        onClick={handleNext}

    >

        Next

    </button>

</div>
                </div>

            </div>

        </div>

    );

}

export default VehicleSelectionPage;