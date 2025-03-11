import React from "react";
import Tab from "./Tabs.component";

type Props = {
  tabs: { title: string; link: string }[];
  activeTab: string;
  setActiveTab: (tab: string) => void;
};

const TabList: React.FC<Props> = ({ tabs, activeTab, setActiveTab  }) => {
  return (
    <nav className="w-full flex justify-center border-b border-gray-300">
      <ul className="flex gap-8 p-4">
        {tabs.map(({ title, link }) => (
          <Tab
            key={title}
            title={title}
            link={link}
            isActive={activeTab === link}
            onClick={() => setActiveTab(link)}
          />
        ))}
      </ul>
    </nav>
  );
};

export default TabList;
