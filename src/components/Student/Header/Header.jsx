import React from "react";
import { Link } from "react-router-dom";
import { FaSun, FaMoon } from "react-icons/fa";
import { FiBell } from "react-icons/fi";

import { useDarkMode } from "../../../contexts/ThemeContext";
import styles from "./Header.module.css";

const Header = () => {
  const { isDarkMode, toggleTheme } = useDarkMode();

  return (
    <header
      className={`${styles.header} ${
        isDarkMode ? styles.darkHeader : styles.lightHeader
      }`}
    >
      <div className={styles.logo}>Team Space</div>
      <nav className={styles.nav}>
        <Link to="/" className={styles.navLink}>
          Home
        </Link>
        <Link to="/about" className={styles.navLink}>
          About
        </Link>
        <Link to="/profile" className={styles.navLink}>
          Profile
        </Link>
      </nav>
      <div className={styles.icons}>
        <button className={styles.iconButton} aria-label="Notifications">
          <FiBell className={styles.icon} />
        </button>
        <button
          className={styles.iconButton}
          onClick={toggleTheme}
          aria-label="Toggle Theme"
        >
          {isDarkMode ? (
            <FaMoon size={20} className={styles.icon} />
          ) : (
            <FaSun size={20} className={styles.icon} />
          )}
        </button>
        <Link to="/Login/signin" className={styles.joinNow}>
          Join Now
        </Link>
      </div>
    </header>
  );
};

export default Header;
