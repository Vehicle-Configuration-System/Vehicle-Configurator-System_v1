import { useEffect, useState } from "react";

import { useNavigate } from "react-router-dom";

import {

    getVehicleSegments,

    getManufacturers,

    getModels

} from "../services/vehicleService";

function WelcomePage() {

    const navigate = useNavigate();

    const [segments, setSegments] = useState([]);

    const [manufacturers, setManufacturers] = useState([]);

    const [models, setModels] = useState([]);

    const [segmentId, setSegmentId] = useState("");

    const [manufacturerId, setManufacturerId] = useState("");

    const [modelId, setModelId] = useState("");

    const [quantity, setQuantity] = useState("");

    const [minimumQuantity, setMinimumQuantity] = useState(0);


    // Load Segments

    useEffect(() => {

        loadSegments();

    }, []);


    async function loadSegments() {

        try {

            const data = await getVehicleSegments();

            setSegments(data);

        }

        catch (error) {

            console.log(error);

        }

    }


    async function handleSegmentChange(e) {

        const id = e.target.value;

        setSegmentId(id);

        setManufacturerId("");

        setModelId("");

        setModels([]);

        const selected = segments.find(
            (item) => item.segmentId == id
        );

        if (selected) {

            setMinimumQuantity(selected.minimumQuantity);

            setQuantity(selected.minimumQuantity);

        }

        const company = await getManufacturers(id);

        setManufacturers(company);

    }


    async function handleManufacturerChange(e) {

        const id = e.target.value;

        setManufacturerId(id);

        setModelId("");

        const data = await getModels(id);

        setModels(data);

    }


    function handleGo() {

        if (
            !segmentId ||
            !manufacturerId ||
            !modelId
        ) {

            alert("Please complete all selections");

            return;

        }

        if (quantity < minimumQuantity) {

            alert(

                "Minimum Quantity should be " +

                minimumQuantity

            );

            return;

        }

        navigate("/default-config", {

            state: {

                segmentId,

                manufacturerId,

                modelId,

                quantity

            }

        });

    }


    return (

        <div className="container mt-5">

            <div className="card shadow p-4">

                <h2 className="text-center mb-4">

                    Welcome Page

                </h2>

                <div className="mb-3">

                    <label>

                        Vehicle Segment

                    </label>

                    <select

                        className="form-select"

                        value={segmentId}

                        onChange={handleSegmentChange}

                    >

                        <option value="">

                            Select Segment

                        </option>

                        {

                            segments.map((item) => (

                                <option

                                    key={item.segmentId}

                                    value={item.segmentId}

                                >

                                    {item.segmentName}

                                </option>

                            ))

                        }

                    </select>

                </div>

                <div className="mb-3">

                    <label>

                        Manufacturer

                    </label>

                    <select

                        className="form-select"

                        value={manufacturerId}

                        onChange={handleManufacturerChange}

                    >

                        <option value="">

                            Select Manufacturer

                        </option>

                        {

                            manufacturers.map((item) => (

                                <option

                                    key={item.manufacturerId}

                                    value={item.manufacturerId}

                                >

                                    {item.manufacturerName}

                                </option>

                            ))

                        }

                    </select>

                </div>

                <div className="mb-3">

                    <label>

                        Vehicle Model

                    </label>

                    <select

                        className="form-select"

                        value={modelId}

                        onChange={(e) =>
                            setModelId(e.target.value)
                        }

                    >

                        <option value="">

                            Select Model

                        </option>

                        {

                            models.map((item) => (

                                <option

                                    key={item.modelId}

                                    value={item.modelId}

                                >

                                    {item.modelName}

                                </option>

                            ))

                        }

                    </select>

                </div>

                <div className="mb-4">

                    <label>

                        Quantity

                    </label>

                    <input

                        type="number"

                        className="form-control"

                        min={minimumQuantity}

                        value={quantity}

                        onChange={(e) =>
                            setQuantity(e.target.value)
                        }

                    />

                    <small>

                        Minimum Quantity :

                        {minimumQuantity}

                    </small>

                </div>

                <button

                    className="btn btn-primary"

                    onClick={handleGo}

                >

                    Go

                </button>

            </div>

        </div>

    );

}

export default WelcomePage;