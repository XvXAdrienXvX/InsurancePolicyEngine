import React, { ReactNode } from "react";

type Props = {
  handleClick: () => void;
  label?: string;
  icon?: ReactNode;
  className?: string;
  iconStyle?: string;
  type?: "button" | "submit" | "reset";
  disabled?: boolean;
};

const Button : React.FC<Props>= ({
  handleClick,
  label,
  icon,
  className,
  iconStyle,
  type = "button",
  disabled = false,
}: Props) => {
  return (
    <button
      type={type}
      className={className}
      onClick={handleClick}
      disabled={disabled}
      aria-label={label}
    >
      {icon && <span className={iconStyle}>{icon}</span>}{" "}
      {label}
    </button>
  );
};

export default Button;
