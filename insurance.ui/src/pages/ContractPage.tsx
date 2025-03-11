import React, { Fragment, useState } from "react";
import Toolbar from "../components/toolbar/Toolbar.component";
import Modal from "../components/modals/Modal.component";
import { Form, Formik } from "formik";
import FormField from "../components/forms/FormField.component";
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

  const onContractFormSubmit = (values: { contractNumber: string; startDate: string; endDate: string }) => {
    console.log(values);
    setIsModalVisible(false);
  };

  const validationSchema = Yup.object({
    contractNumber: Yup.string().required("Contract Number is required"),
    startDate: Yup.date().required("Start Date is required"),
    endDate: Yup.date().required("End Date is required"),
  });

  return (
    <Fragment>
      <div className="flex flex-row h-screen">
        <div className="w-full">
          <Toolbar buttons={toolbarButtons} />
        </div>
      </div>

      {isModalVisible && (
        <Formik
          initialValues={{
            contractNumber: "",
            startDate: "",
            endDate: "",
          }}
          validationSchema={validationSchema}
          onSubmit={(values) => {
            onContractFormSubmit(values);
          }}
        >
          {({ handleSubmit }) => (
            <Modal
              show={isModalVisible}
              onSubmit={() => handleSubmit}
              close={handleCloseModal}
              submitLabel="Add Contract"
              closeLabel="Cancel"
              title="Add Contract"
              body={
                <Form>
                  <div className="flex flex-col space-y-4">
                    <div className="w-full">
                      <FormField label="Contract Number" name="contractNumber" type="text" />
                    </div>
                    <div className="w-full">
                      <FormField label="Start Date" name="startDate" type="date" />
                    </div>
                    <div className="w-full">
                      <FormField label="End Date" name="endDate" type="date" />
                    </div>
                  </div>
                </Form>
              }
            />
          )}
        </Formik>
      )}
    </Fragment>
  );
};

export default ContractPage;
