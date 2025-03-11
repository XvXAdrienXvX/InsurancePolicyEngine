import AppRouter from "./routes";
import TabList from "./components/navigation/TabList.component";
import { useState } from "react";

const App = () => {
  const [activeTab, setActiveTab] = useState("/contracts");

  const tabs = [
    { title: "Contracts", link: "/contracts" },
    { title: "Policies", link: "/policies" },
    { title: "Claims", link: "/claims" },
  ];

  return (
    <div className="flex flex-col items-center min-h-screen bg-gray-200">
      <TabList tabs={tabs} activeTab={activeTab} setActiveTab={setActiveTab} />

      {/* Page Content */}
      <div className="w-full max-w-7xl p-6 bg-gray-200 mt-6">
        <AppRouter />
      </div>
    </div>
  );
};

export default App;
