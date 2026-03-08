import { BrowserRouter, Routes, Route } from "react-router-dom";
import CitizensPage from "./pages/CitizensPage";
import HomePage from "./pages/HomePage";
import AllRefundsPage from "./pages/AllRefundsPage";
import CitizenDetailsPage from "./pages/CitizenDetailsPage";
import { ThemeProvider, createTheme } from "@mui/material/styles";
import CssBaseline from "@mui/material/CssBaseline";

const theme = createTheme({
  direction: "rtl",
  typography: {
    fontFamily: "Rubik, Arial"
  }
});

function App() {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/citizen/:id" element={<CitizensPage />} />
        <Route path="/allRefunds" element={<AllRefundsPage />} />
        <Route path="/citizenDetails/:citizenId/:requestId" element={<CitizenDetailsPage />}/>
      </Routes>
    </BrowserRouter>
    </ThemeProvider>
  );
}

export default App