import { BrowserRouter, Routes, Route } from "react-router-dom";

import Navbar from "./components/Navbar";

import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";
import HomePage from "./pages/HomePage";
import WelcomePage from "./pages/WelcomePage";
import DefaultConfigurationPage from "./pages/DefaultConfigurationPage";
import SegmentPage from "./pages/SegmentPage";
import AboutPage from "./pages/AboutPage";
import ContactPage from "./pages/ContactPage";
import FeedbackPage from "./pages/FeedbackPage";
import ManufacturerPage from "./pages/ManufacturerPage";
import ModelPage from "./pages/ModelPage";
import QuantityPage from "./pages/QuantityPage";
import ConfigurePage from "./pages/ConfigurePage";
import VehicleSelectionPage from "./pages/VehicleSelectionPage";

function App() {
  return (
    <BrowserRouter>
      <Navbar />

      <Routes>
         
        <Route path="/" element={<HomePage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/welcome" element={<WelcomePage />} />
        
        {/* <Route path="/segment" element={<SegmentPage />}/> */}
         <Route
                    path="/vehicle-selection"
                    element={<VehicleSelectionPage />}
                />
                        <Route path="/configure" element={<ConfigurePage />} />

                <Route
    path="/default-config"
    element={<DefaultConfigurationPage />}
/>
         <Route path="/about" element={<AboutPage />} />
         <Route path="/contact" element={<ContactPage />} />
        <Route path="/feedback" element={<FeedbackPage />} />
          <Route path="/manufacturer" element={<ManufacturerPage />}/>
         <Route path="/manufacturer/:segmentId" element={<ManufacturerPage />}/>
           <Route path="/model/:manufacturerId" element={<ModelPage />}/>
           <Route  path="/quantity/:modelId"  element={<QuantityPage />}/>
           <Route  path="/default-config/:modelId"  element={<DefaultConfigurationPage />}/>
           <Route path="/configure/:modelId" element={<ConfigurePage />}
/>


      </Routes>
    </BrowserRouter>
  );
}

export default App;