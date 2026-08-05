import { Link } from "react-router-dom";

function HomePage() {
  return (
    <>
      {/* Hero Section */}
      <section className="bg-primary text-white py-5">
        <div className="container">
          <div className="row align-items-center">

            <div className="col-md-6">

              <h1 className="display-4 fw-bold">
                Welcome to Vehicle Configurator
              </h1>

              <p className="lead mt-3">
                Design and configure your dream vehicle with ease.
                Select manufacturers, choose models, customize
                features, compare prices, and generate invoices
                instantly.
              </p>

              <Link
                to="/login"
                className="btn btn-light btn-lg mt-3 me-3"
              >
                Sign-On
              </Link>

              <Link
                to="/register"
                className="btn btn-outline-light btn-lg mt-3"
              >
                Register
              </Link>

            </div>

            <div className="col-md-6 text-center">

              <img
                src="https://images.unsplash.com/photo-1492144534655-ae79c964c9d7?w=900"
                alt="Vehicle"
                className="img-fluid rounded shadow"
              />

            </div>

          </div>
        </div>
      </section>

      {/* Company Overview */}

      <section className="container py-5">

        <div className="text-center mb-5">

          <h2 className="fw-bold text-primary">
            About Our Company
          </h2>

          <p className="text-muted">

            Vehicle Configurator is an intelligent automobile
            configuration platform that allows customers to build
            vehicles according to their preferences.

          </p>

        </div>

        <div className="row">

          <div className="col-md-4">

            <div className="card shadow-sm h-100">

              <div className="card-body">

                <h4 className="text-primary">
                  Our Mission
                </h4>

                <p>
                  Deliver a simple and user-friendly vehicle
                  configuration system with transparent pricing
                  and instant quotation generation.
                </p>

              </div>

            </div>

          </div>

          <div className="col-md-4">

            <div className="card shadow-sm h-100">

              <div className="card-body">

                <h4 className="text-primary">
                  Our Vision
                </h4>

                <p>
                  Become the leading digital platform for
                  personalized vehicle customization and
                  online automobile purchasing.
                </p>

              </div>

            </div>

          </div>

          <div className="col-md-4">

            <div className="card shadow-sm h-100">

              <div className="card-body">

                <h4 className="text-primary">
                  Our Values
                </h4>

                <p>
                  Innovation, customer satisfaction,
                  transparency, quality service,
                  and continuous improvement.
                </p>

              </div>

            </div>

          </div>

        </div>

      </section>

      {/* Services */}

      <section className="bg-light py-5">

        <div className="container">

          <h2 className="text-center fw-bold text-primary mb-5">
            Our Services
          </h2>

          <div className="row g-4">

            <div className="col-md-3">

              <div className="card h-100 shadow-sm">

                <div className="card-body text-center">

                  <h5>Vehicle Configuration</h5>

                  <p>
                    Configure your preferred vehicle with
                    different models and features.
                  </p>

                </div>

              </div>

            </div>

            <div className="col-md-3">

              <div className="card h-100 shadow-sm">

                <div className="card-body text-center">

                  <h5>Price Estimation</h5>

                  <p>
                    Automatic price calculation based on
                    selected components.
                  </p>

                </div>

              </div>

            </div>

            <div className="col-md-3">

              <div className="card h-100 shadow-sm">

                <div className="card-body text-center">

                  <h5>Invoice Generation</h5>

                  <p>
                    Generate and print invoices
                    with complete configuration details.
                  </p>

                </div>

              </div>

            </div>

            <div className="col-md-3">

              <div className="card h-100 shadow-sm">

                <div className="card-body text-center">

                  <h5>Customer Support</h5>

                  <p>
                    Contact our support team
                    anytime for assistance.
                  </p>

                </div>

              </div>

            </div>

          </div>

        </div>

      </section>

      {/* Why Choose Us */}

      <section className="container py-5">

        <h2 className="text-center fw-bold text-primary mb-5">
          Why Choose Us?
        </h2>

        <div className="row text-center">

          <div className="col-md-3">

            <h1>🚗</h1>

            <h5>Easy Configuration</h5>

            <p>Simple step-by-step vehicle customization.</p>

          </div>

          <div className="col-md-3">

            <h1>⚡</h1>

            <h5>Fast Processing</h5>

            <p>Instant quotation and price calculation.</p>

          </div>

          <div className="col-md-3">

            <h1>💰</h1>

            <h5>Transparent Pricing</h5>

            <p>No hidden costs or additional charges.</p>

          </div>

          <div className="col-md-3">

            <h1>🛡</h1>

            <h5>Trusted Service</h5>

            <p>Reliable and secure configuration platform.</p>

          </div>

        </div>

      </section>

      {/* Call to Action */}

      <section className="bg-primary text-white py-5">

        <div className="container text-center">

          

          <p>

            Create an account or sign in to begin
            configuring your vehicle.

          </p>

          <Link
            to="/login"
            className="btn btn-light btn-lg me-3"
          >
            Login
          </Link>

          <Link
            to="/register"
            className="btn btn-outline-light btn-lg"
          >
            Register
          </Link>

        </div>

      </section>
    </>
  );
}

export default HomePage;