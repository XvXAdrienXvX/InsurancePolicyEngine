import React from "react";

type ButtonConfig = {
  label: string;
  onClick: () => void;
};

type ToolbarProps = {
  buttons: ButtonConfig[];
};

const Toolbar: React.FC<ToolbarProps> = ({ buttons }: ToolbarProps) => {
    return (
        <div className="flex w-full gap-10 p-4 bg-gray-100 rounded-lg justify-end shadow-md">
          {buttons.map((button, index) => (
            <button
              key={index}
              onClick={button.onClick}
              className="px-4 py-2 text-white bg-blue-500 rounded-md hover:bg-blue-700 transition-colors duration-300"
            >
              {button.label}
            </button>
          ))}
        </div>
      );
};

export default Toolbar;
