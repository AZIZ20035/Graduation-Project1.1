import { useState } from "react";
import Sidebar from "../../../components/Admin/Sidebar/Sidebar";
import Header from "../../../components/Admin/Header/Header";
import AdminHero from "../../../components/Admin/HeroSection/Hero";
import styles from "./Home.module.css";
import NewsSection from "../../../components/Admin/NewsSection/News";

export default function AdminHomePage() {
  const [isSidebarOpen, setIsSidebarOpen] = useState(true);

  return (
    <div className={styles.container}>
      <div className={styles.sidebar}>
        <Sidebar isOpen={isSidebarOpen} />
      </div>

      <div className={styles.mainContent}>
        <Header toggleSidebar={() => setIsSidebarOpen(!isSidebarOpen)} />
        <main className={styles.content}>
          <AdminHero />
          <NewsSection />
        </main>
      </div>
    </div>
  );
}
