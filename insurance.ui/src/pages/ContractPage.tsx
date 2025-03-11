import React from "react";
import Toolbar from "../components/toolbar/Toolbar.component";

const ContractPage: React.FC = () => {
  const handleAdd = () => {
   
  };

  const handleDelete = () => {
   
  };

  const toolbarButtons = [
    { label: "Add", onClick: handleAdd },
    { label: "Delete", onClick: handleDelete },
  ];

  return (
    <div className="flex flex-row h-screen">
      <div className="w-full">
        <Toolbar buttons={toolbarButtons} />
      </div>
    </div>
  );
};

export default ContractPage;
