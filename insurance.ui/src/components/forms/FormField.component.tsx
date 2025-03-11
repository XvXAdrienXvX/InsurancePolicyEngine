import { ErrorMessage, Field, useFormikContext } from "formik";
import { FC } from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

type Props = {
  name: string;
  label: string;
  type: "text" | "email" | "password" | "select" | "checkbox" | "date";
  options?: { value: string; label: string }[];
  placeholder?: string;
};

const FormField: FC<Props> = ({ name, label, type, options, placeholder }) => {
  const { setFieldValue, values, errors, touched } = useFormikContext<{ [key: string]: undefined }>();

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
            className={`p-2 border rounded-md w-full ${
              errors[name] && touched[name] ? "border-red-500" : "border-gray-300"
            }`}
          />
        );
      case "select":
        return (
          <Field as="select" name={name} id={name} className="p-2 border border-gray-300 rounded-md w-full">
            {options?.map((option) => (
              <option key={option.value} value={option.value}>
                {option.label}
              </option>
            ))}
          </Field>
        );
      case "checkbox":
        return (
          <Field type="checkbox" name={name} id={name} className="mr-2 leading-tight" />
        );
      case "date":
        return (
          <DatePicker
            selected={values[name] ? new Date(values[name]) : null}
            onChange={(date) => setFieldValue(name, date)}
            className={`p-2 border rounded-md w-full ${
              errors[name] && touched[name] ? "border-red-500" : "border-gray-300"
            }`}
            dateFormat="yyyy-MM-dd"
            placeholderText={placeholder || "Select a date"}
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