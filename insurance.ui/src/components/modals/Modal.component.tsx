import { JSX } from "react";
import Button from "../buttons/Button.component";

type Props = {
  title?: string;
  submitLabel?: string;
  show?: boolean;
  onSubmit: (...args: unknown[]) => void;
  close?: VoidFunction;
  closeLabel?: string;
  body?: JSX.Element;
  className?: string;
  hideSubmitButton?: boolean;
  hideCancelButton?: boolean;
  modalBackgroundClass?: string;
};

const Modal = ({
  title,
  show = false,
  onSubmit,
  submitLabel = "Submit",
  close = () => {},
  closeLabel = "Cancel",
  body,
  className = "",
  hideSubmitButton,
  hideCancelButton,
  modalBackgroundClass = "",
}: Props) => {
  if (!show) return null;

  return (
    <div
      className={`fixed inset-0 flex items-center justify-center bg-opacity-50 z-50 ${modalBackgroundClass}`}
      onClick={close}
    >
      <div
        className={`bg-white p-6 rounded-lg shadow-lg max-w-md w-full ${className}`}
        onClick={(e) => e.stopPropagation()}
      >
        <header className="flex justify-between items-center border-b pb-3">
          <h2 className="text-lg font-semibold">{title}</h2>
        </header>

        <main className="py-4">{body}</main>

        <footer className="flex justify-end space-x-4">
          {!hideCancelButton && (
            <Button
              handleClick={close}
              label={closeLabel}
              className="px-4 py-2 text-white bg-gray-500 rounded-md hover:bg-gray-700 transition-colors duration-300"
            />
          )}

          {!hideSubmitButton && (
            <Button
              handleClick={onSubmit}
              label={submitLabel}
              className="px-4 py-2 text-white bg-blue-500 rounded-md hover:bg-blue-700 transition-colors duration-300"
            />
          )}
        </footer>
      </div>
    </div>
  );
};

export default Modal;
