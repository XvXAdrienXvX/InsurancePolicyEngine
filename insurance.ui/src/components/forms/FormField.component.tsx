import { ErrorMessage, Field } from "formik";
import { FC } from "react";

type Props = {
  name: string;
  label: string;
  type: "text" | "email" | "password" | "select" | "checkbox";
  options?: { value: string; label: string }[]; // dropdown
  placeholder?: string;
};

const FormField: FC<Props> = ({
  name,
  label,
  type,
  options,
  placeholder,
}: Props) => {
  const renderField = () => {
    switch (type) {
      case "text":
      case "email":
      case "password":
        return (
          <Field
            type={type}
            name={name}
            id={name}
            placeholder={placeholder}
            className="p-2 border border-gray-300 rounded-md"
          />
        );
      case "select":
        return (
          <Field
            as="select"
            name={name}
            id={name}
            className="p-2 border border-gray-300 rounded-md"
          >
            {options?.map((option) => (
              <option key={option.value} value={option.value}>
                {option.label}
              </option>
            ))}
          </Field>
        );
      case "checkbox":
        return (
          <Field
            type="checkbox"
            name={name}
            id={name}
            className="mr-2 leading-tight"
          />
        );
      default:
        return null;
    }
  };

  return (
    <div className="mb-4">
      <label htmlFor={name} className="block text-sm font-medium text-gray-700">
        {label}
      </label>
      {renderField()}
      <ErrorMessage name={name} component="div" className="text-sm text-red-600 mt-1" />
    </div>
  );

};

export default FormField;
