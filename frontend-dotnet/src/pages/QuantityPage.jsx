import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

function QuantityPage() {

    const navigate = useNavigate();

    const segment = JSON.parse(
        sessionStorage.getItem("selectedSegment")
    );

    const manufacturer = JSON.parse(
        sessionStorage.getItem("selectedManufacturer")
    );

    const model = JSON.parse(
        sessionStorage.getItem("selectedModel")
    );

    const [quantity, setQuantity] = useState(
        model?.minQty || 1
    );

    useEffect(() => {

        if (!model) {

            navigate("/segment");

        }

    }, [model, navigate]);

    const handleNext = () => {

        if (!model) {

            alert("Please select a model.");

            return;

        }

        if (quantity < model.minQty) {

            alert(`Minimum quantity is ${model.minQty}`);

            return;

        }

        sessionStorage.setItem(
            "selectedQuantity",
            quantity
        );

        navigate(`/default-config/${model.modelId}?qty=${quantity}`);

    };

    const handleBack = () => {

        if (manufacturer) {

            navigate(`/model/${manufacturer.manufacturerId}`);

        }
        else {

            navigate("/manufacturer");

        }

    };

    return (

        <div className="container mt-5">

            <div className="card shadow">

                <div className="card-header bg-primary text-white">

                    <h3>Vehicle Quantity</h3>

                </div>

                <div className="card-body">

                    {!model && (

                        <div className="alert alert-danger">

                            No model selected.

                        </div>

                    )}

                    <div className="mb-3">

                        <label className="form-label">

                            Selected Segment

                        </label>

                        <input

                            type="text"

                            className="form-control"

                            value={segment?.segName || ""}

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

                            value={manufacturer?.manufacturerName || ""}

                            readOnly

                        />

                    </div>

                    <div className="mb-3">

                        <label className="form-label">

                            Selected Model

                        </label>

                        <input

                            type="text"

                            className="form-control"

                            value={model?.modelName || ""}

                            readOnly

                        />

                    </div>

                    <div className="mb-3">

                        <label className="form-label">

                            Base Price

                        </label>

                        <input

                            type="text"

                            className="form-control"

                            value={
                                model
                                    ? `₹ ${model.basePrice.toLocaleString()}`
                                    : ""
                            }

                            readOnly

                        />

                    </div>

                    <div className="mb-3">

                        <label className="form-label">

                            Minimum Quantity

                        </label>

                        <input

                            type="number"

                            className="form-control"

                            value={model?.minQty || ""}

                            readOnly

                        />

                    </div>

                    <div className="mb-4">

                        <label className="form-label">

                            Enter Quantity

                        </label>

                        <input

                            type="number"

                            className="form-control"

                            min={model?.minQty || 1}

                            value={quantity}

                            onChange={(e) =>
                                setQuantity(Number(e.target.value))
                            }

                        />

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

                        >

                            Next

                        </button>

                    </div>

                </div>

            </div>

        </div>

    );

}

export default QuantityPage;