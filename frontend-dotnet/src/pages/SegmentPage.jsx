import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

import { getAllSegments } from "../services/segmentService";

function SegmentPage() {

    const navigate = useNavigate();

    const [segments, setSegments] = useState([]);

    const [selectedSegment, setSelectedSegment] = useState("");

    const [loading, setLoading] = useState(true);

    const [error, setError] = useState("");

    useEffect(() => {

        loadSegments();

    }, []);

    const loadSegments = async () => {

        try {

            const data = await getAllSegments();

            setSegments(data);

        }
        catch (err) {

            console.log(err);

            setError("Unable to load segments.");

        }
        finally {

            setLoading(false);

        }

    };

    const handleNext = () => {

        if (selectedSegment === "") {

            alert("Please select a segment.");

            return;

        }

        const segment = segments.find(
            s => String(s.segId) === selectedSegment
        );

        sessionStorage.setItem(
            "selectedSegment",
            JSON.stringify(segment)
        );

        navigate(`/manufacturer/${selectedSegment}`);

    };

    return (

        <div className="container mt-5">

            <div className="card shadow">

                <div className="card-header bg-primary text-white">

                    <h3>Select Vehicle Segment</h3>

                </div>

                <div className="card-body">

                    {loading && (

                        <div className="alert alert-info">

                            Loading segments...

                        </div>

                    )}

                    {error && (

                        <div className="alert alert-danger">

                            {error}

                        </div>

                    )}

                    <div className="mb-4">

                        <label className="form-label">

                            Vehicle Segment

                        </label>

                        <select

                            className="form-select"

                            value={selectedSegment}

                            onChange={(e) =>
                                setSelectedSegment(e.target.value)
                            }

                            disabled={loading}

                        >

                            <option value="">

                                Select Segment

                            </option>

                            {

                                segments.map(segment => (

                                    <option

                                        key={segment.segId}

                                        value={segment.segId}

                                    >

                                        {segment.segName}

                                    </option>

                                ))

                            }

                        </select>

                    </div>

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

    );

}

export default SegmentPage;