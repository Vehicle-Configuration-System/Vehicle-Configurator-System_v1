import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

import { getModelsByManufacturer } from "../services/modelService";

function ModelPage() {

    const navigate = useNavigate();

    const { manufacturerId } = useParams();

    const [models, setModels] = useState([]);

    const [selectedModel, setSelectedModel] = useState("");

    const [loading, setLoading] = useState(true);

    const [error, setError] = useState("");

    const selectedManufacturer = JSON.parse(
        sessionStorage.getItem("selectedManufacturer")
    );

    const selectedSegment = JSON.parse(
        sessionStorage.getItem("selectedSegment")
    );

    useEffect(() => {

        loadModels();

    }, [manufacturerId, selectedSegment]);

    const loadModels = async () => {

        try {

            const data = await getModelsByManufacturer(manufacturerId, selectedSegment.segId);

            setModels(data);

        }

        catch (err) {

            console.log(err);

            setError("Unable to load models.");

        }

        finally {

            setLoading(false);

        }

    };

    const handleNext = () => {

        if (selectedModel === "") {

            alert("Please select a model.");

            return;

        }

        const model = models.find(
            m => String(m.modelId) === selectedModel
        );

        sessionStorage.setItem(
            "selectedModel",
            JSON.stringify(model)
        );

        navigate(`/quantity/${selectedModel}`);

    };

    const handleBack = () => {

        navigate(`/manufacturer/${selectedSegment?.segId}`);

    };

    return (

        <div className="container mt-5">

            <div className="card shadow">

                <div className="card-header bg-primary text-white">

                    <h3>Select Vehicle Model</h3>

                </div>

                <div className="card-body">

                    {loading && (

                        <div className="alert alert-info">

                            Loading models...

                        </div>

                    )}

                    {error && (

                        <div className="alert alert-danger">

                            {error}

                        </div>

                    )}

                    <div className="mb-3">

                        <label className="form-label">

                            Selected Segment

                        </label>

                        <input

                            type="text"

                            className="form-control"

                            value={selectedSegment?.segName || ""}

                            readOnly

                        />

                    </div>

                    <div className="mb-3">

                        <label className="form-label">

                            Selected Manufacturer

                        </label>

                        <input

                            type="text"

                            className="form-control"

                            value={selectedManufacturer?.manufacturerName || ""}

                            readOnly

                        />

                    </div>

                    <div className="mb-4">

                        <label className="form-label">

                            Vehicle Model

                        </label>

                        <select

                            className="form-select"

                            value={selectedModel}

                            onChange={(e) =>
                                setSelectedModel(e.target.value)
                            }

                            disabled={loading}

                        >

                            <option value="">

                                Select Model

                            </option>

                            {

                                models.map(model => (

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

                    <div className="d-flex justify-content-between">

                        <button

                            className="btn btn-secondary"

                            onClick={handleBack}

                        >

                            Back

                        </button>

                        <button

                            className="btn btn-primary"

                            onClick={handleNext}

                            disabled={loading}

                        >

                            Next

                        </button>

                    </div>

                </div>

            </div>

        </div>

    );

}

export default ModelPage;