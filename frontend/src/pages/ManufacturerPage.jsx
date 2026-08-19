import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

import { getManufacturersBySegment } from "../services/manufacturerService";

function ManufacturerPage() {

    const navigate = useNavigate();

    const { segmentId } = useParams();

    const [manufacturers, setManufacturers] = useState([]);

    const [selectedManufacturer, setSelectedManufacturer] = useState("");

    const [loading, setLoading] = useState(true);

    const [error, setError] = useState("");

    const selectedSegment = JSON.parse(
        sessionStorage.getItem("selectedSegment")
    );

    useEffect(() => {

        loadManufacturers();

    }, []);

    const loadManufacturers = async () => {

        try {

            const data = await getManufacturersBySegment(segmentId);

            setManufacturers(data);

        }
        catch (err) {

            console.log(err);

            setError("Unable to load manufacturers.");

        }
        finally {

            setLoading(false);

        }

    };

    const handleNext = () => {

        if (selectedManufacturer === "") {

            alert("Please select a manufacturer.");

            return;

        }

        const manufacturer = manufacturers.find(
            m => String(m.manufacturerId) === selectedManufacturer
        );

        sessionStorage.setItem(
            "selectedManufacturer",
            JSON.stringify(manufacturer)
        );

        navigate(`/model/${selectedManufacturer}`);

    };

    const handleBack = () => {

        navigate("/segment");

    };

    return (

        <div className="container mt-5">

            <div className="card shadow">

                <div className="card-header bg-primary text-white">

                    <h3>Select Manufacturer</h3>

                </div>

                <div className="card-body">

                    {loading && (

                        <div className="alert alert-info">

                            Loading manufacturers...

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

                    <div className="mb-4">

                        <label className="form-label">

                            Manufacturer

                        </label>

                        <select

                            className="form-select"

                            value={selectedManufacturer}

                            onChange={(e) =>
                                setSelectedManufacturer(e.target.value)
                            }

                            disabled={loading}

                        >

                            <option value="">

                                Select Manufacturer

                            </option>

                            {

                                manufacturers.map(manufacturer => (

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

export default ManufacturerPage;