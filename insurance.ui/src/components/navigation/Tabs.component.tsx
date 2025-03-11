import React from "react";
import { NavLink } from "react-router-dom";

type Props = {
  title: string;
  link: string;
  isActive?: boolean;
  onClick: () => void;
};

const Tab: React.FC<Props> = ({ title, link, isActive, onClick }) => {
  return (
    <li className="relative">
      <NavLink
        to={link}
        onClick={onClick}
        className={`pb-2 text-gray-600 hover:text-blue-500 transition ${
          isActive ? "text-blue-600 font-medium" : ""
        }`}
      >
        {title}
        <span
          className={`absolute left-0 bottom-0 w-full h-[2px] bg-blue-600 transform scale-x-0 transition-transform duration-300 ${
            isActive ? "scale-x-100" : ""
          }`}
        ></span>
      </NavLink>
    </li>
  );
};

export default Tab;
