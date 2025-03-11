import React, { Fragment, useState } from "react";
import Toolbar from "../components/toolbar/Toolbar.component";
import Modal from "../components/modals/Modal.component";
import { Form, Formik } from "formik";
import FormField from "../components/forms/FormField.component";
import Button from "../components/buttons/Button.component";
import * as Yup from "yup";

const ContractPage: React.FC = () => {
  const [isModalVisible, setIsModalVisible] = useState(false);

  const handleAdd = () => {
    setIsModalVisible(true);
  };

  const handleDelete = () => {};

  const handleCloseModal = () => {
    setIsModalVisible(false);
  };

  const toolbarButtons = [
    { label: "Add", onClick: handleAdd },
    { label: "Delete", onClick: handleDelete },
  ];

  const validationSchema = Yup.object({
    contractName: Yup.string().required("Contract Name is required"),
    contractDetails: Yup.string().required("Contract Details are required"),
    contractDate: Yup.date().required("Contract Date is required"),
  });

  const ModalBody = () => (
    <Formik
      initialValues={{
        contractName: "",
        contractDetails: "",
        contractDate: "",
      }}
      validationSchema={validationSchema}
      onSubmit={(values, { setSubmitting }) => {
        console.log(values);
        setSubmitting(false);
      }}
    >
      {({ handleSubmit }) => (
        <Form>
          <div className="flex flex-col space-y-4">
            <div className="w-full">
              <FormField
                label="Contract Name"
                name="contractName"
                type={"text"}
              />
            </div>
            <div className="w-full">
              <FormField label="Start Date" name="startDate" type={"date"} />
            </div>
            <div className="w-full">
              <FormField label="End Date" name="endDate" type={"date"} />
            </div>
          </div>

          <Button
            handleClick={handleSubmit}
            label="Add Contract"
            className="px-4 py-2 text-white bg-blue-500 rounded-md hover:bg-blue-700 transition-colors duration-300"
          />
        </Form>
      )}
    </Formik>
  );

  return (
    <Fragment>
      <div className="flex flex-row h-screen">
        <div className="w-full">
          <Toolbar buttons={toolbarButtons} />
        </div>
      </div>
      <Modal
        show={isModalVisible}
        onSubmit={() => {
          setIsModalVisible(false);
        }}
        close={handleCloseModal}
        submitLabel="Add Contract"
        closeLabel="Cancel"
        title="Add Contract"
        body={<ModalBody />}
      />
    </Fragment>
  );
};

export default ContractPage;
