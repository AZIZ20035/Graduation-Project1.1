import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";
import styles from "./SignInPage.module.css";
import FormInput from "../../../components/Student/FormInput/FormInput";
import Button from "../../../components/Student/Button/Button";

const SignInForm = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [termsAccepted, setTermsAccepted] = useState(false);
  const navigate = useNavigate();

  const handleLogin = async () => {
    const api_url = "";
    try {
      const response = await fetch(api_url, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ email, password }),
      });

      if (!response.ok) {
        throw new Error("Failed");
      }

      const data = await response.json();
      console.log("Success:", data);
      navigate("/");
    } catch (error) {
      console.error("Error:", error);
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!termsAccepted) return;
    handleLogin();
  };

  return (
    <div className={styles.container}>
      <div className={styles.imageSection}>
        <Link to="/" className={styles.backToWebsite}>
          Back to website →
        </Link>
        <div className={styles.overlay}>Streamline Your College Life</div>
        <div className={styles.pagination}>
          <div className={`${styles.dot} ${styles.active}`}></div>
          <div className={styles.dot}></div>
          <div className={styles.dot}></div>
          <div className={styles.dot}></div>
        </div>
      </div>

      <div className={styles.formSection}>
        <h2>
          Start Learning <strong>Today!</strong>
        </h2>
        <p>Log in to explore your courses and track your progress.</p>

        <form className={styles.form} onSubmit={handleSubmit}>
          <FormInput
            type="email"
            placeholder="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
          <FormInput
            type="password"
            placeholder="Enter your password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />

          <div className={styles.terms}>
            <input
              type="checkbox"
              id="terms"
              className={styles.check}
              checked={termsAccepted}
              onChange={() => setTermsAccepted(!termsAccepted)}
            />
            <label htmlFor="terms">
              I agree to the <Link to="/terms">Terms & Conditions</Link>
            </label>
          </div>

          <Button className={styles.login} type="submit">
            Login
          </Button>
        </form>
      </div>
    </div>
  );
};

export default SignInForm;
