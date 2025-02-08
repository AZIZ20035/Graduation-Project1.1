import React, { useState } from "react";
import styles from "./SignInForm.module.css";
import FormInput from "../FormInput/FormInput";
import Button from "../Button/Button";

const SignInForm = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [termsAccepted, setTermsAccepted] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    let api_url = "";
    try {
      const response = await fetch(api_url, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ email, password }),
      });
      const data = await response.json();
      console.log("Success:", data);
    } catch (error) {
      console.error("Error:", error);
    }
  };

  return (
    <div className={styles.signupContainer}>
      <form className={styles.form} onSubmit={handleSubmit}>
        <h2>Start Learning Today!</h2>
        <p>Log in to explore your courses and track your progress.</p>
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
            I agree to the <a href="/terms">Terms & Conditions</a>
          </label>
        </div>
        <Button className={styles.login} type="submit">
          Login
        </Button>
      </form>
    </div>
  );
};

export default SignInForm;
