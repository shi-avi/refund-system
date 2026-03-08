import { BrowserRouter, Routes, Route } from "react-router-dom";
import CitizensPage from "./pages/CitizensPage";
import HomePage from "./pages/HomePage";
import AllRefundsPage from "./pages/AllRefundsPage";
import CitizenDetailsPage from "./pages/CitizenDetailsPage";

function App() {

  return (
    <div>
    <BrowserRouter style={{ direction: "rtl", textAlign: "center" }}>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/citizen/:id" element={<CitizensPage />} />
        <Route path="/allRefunds" element={<AllRefundsPage />} />
        <Route path="/citizenDetails/:citizenId/:requestId" element={<CitizenDetailsPage />}/>
      </Routes>
    </BrowserRouter>
    </div>
  )
}

export default App
