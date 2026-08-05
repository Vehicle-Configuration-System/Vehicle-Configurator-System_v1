import { useState } from "react";

function ContactPage() {

    const [contact, setContact] = useState({

        name: "",

        email: "",

        subject: "",

        message: ""

    });

    function handleChange(e) {

        setContact({

            ...contact,

            [e.target.name]: e.target.value

        });

    }

    function handleSubmit(e) {

        e.preventDefault();

        console.log(contact);

        alert("Your message has been submitted successfully.");

    }

    function handleCancel() {

        setContact({

            name: "",

            email: "",

            subject: "",

            message: ""

        });

    }

    return (

        <div className="container mt-5">

            <div className="card shadow">

                <div className="card-header bg-success text-white">

                    <h2>Contact Us</h2>

                </div>

                <div className="card-body">

                    <form onSubmit={handleSubmit}>

                        <div className="mb-3">

                            <label>Name</label>

                            <input
                                type="text"
                                className="form-control"
                                name="name"
                                value={contact.name}
                                onChange={handleChange}
                                required
                            />

                        </div>

                        <div className="mb-3">

                            <label>Email</label>

                            <input
                                type="email"
                                className="form-control"
                                name="email"
                                value={contact.email}
                                onChange={handleChange}
                                required
                            />

                        </div>

                        <div className="mb-3">

                            <label>Subject</label>

                            <input
                                type="text"
                                className="form-control"
                                name="subject"
                                value={contact.subject}
                                onChange={handleChange}
                                required
                            />

                        </div>

                        <div className="mb-3">

                            <label>Message</label>

                            <textarea
                                className="form-control"
                                rows="5"
                                name="message"
                                value={contact.message}
                                onChange={handleChange}
                                required
                            />

                        </div>

                        <button
                            className="btn btn-success me-2"
                            type="submit"
                        >
                            Submit
                        </button>

                        <button
                            type="button"
                            className="btn btn-secondary"
                            onClick={handleCancel}
                        >
                            Cancel
                        </button>

                    </form>

                </div>

            </div>

        </div>

    );

}

export default ContactPage;