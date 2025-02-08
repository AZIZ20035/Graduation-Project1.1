import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import { BrowserRouter } from "react-router-dom";
import { DarkModeProvider } from "./contexts/ThemeContext";

const root = ReactDOM.createRoot(document.getElementById("root"));

root.render(
  <DarkModeProvider>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </DarkModeProvider>
);
