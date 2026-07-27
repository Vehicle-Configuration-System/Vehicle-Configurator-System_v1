import { useState } from "react";

function FeedbackPage() {

    const [feedback, setFeedback] = useState({

        name: "",

        rating: "",

        comments: ""

    });

    function handleChange(e) {

        setFeedback({

            ...feedback,

            [e.target.name]: e.target.value

        });

    }

    function handleSubmit(e) {

        e.preventDefault();

        console.log(feedback);

        alert("Thank you for your feedback.");

    }

    function handleReset() {

        setFeedback({

            name: "",

            rating: "",

            comments: ""

        });

    }

    return (

        <div className="container mt-5">

            <div className="card shadow">

                <div className="card-header bg-warning">

                    <h2>Feedback</h2>

                </div>

                <div className="card-body">

                    <form onSubmit={handleSubmit}>

                        <div className="mb-3">

                            <label>Name</label>

                            <input
                                type="text"
                                className="form-control"
                                name="name"
                                value={feedback.name}
                                onChange={handleChange}
                                required
                            />

                        </div>

                        <div className="mb-3">

                            <label>Rating</label>

                            <select
                                className="form-select"
                                name="rating"
                                value={feedback.rating}
                                onChange={handleChange}
                                required
                            >

                                <option value="">Select Rating</option>

                                <option value="5">Excellent</option>

                                <option value="4">Very Good</option>

                                <option value="3">Good</option>

                                <option value="2">Average</option>

                                <option value="1">Poor</option>

                            </select>

                        </div>

                        <div className="mb-3">

                            <label>Comments</label>

                            <textarea
                                className="form-control"
                                rows="5"
                                name="comments"
                                value={feedback.comments}
                                onChange={handleChange}
                            />

                        </div>

                        <button
                            className="btn btn-warning me-2"
                            type="submit"
                        >
                            Submit
                        </button>

                        <button
                            className="btn btn-secondary"
                            type="button"
                            onClick={handleReset}
                        >
                            Reset
                        </button>

                    </form>

                </div>

            </div>

        </div>

    );

}

export default FeedbackPage;