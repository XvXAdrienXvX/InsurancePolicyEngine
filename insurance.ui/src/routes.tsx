import { ComponentType, lazy } from "react";
import { Routes, Route } from "react-router-dom";

interface IRoute {
  path: string;
  title?: string;
  component: ComponentType<Record<string, unknown>>;
}

// Lazy Load Components
const ContractPage = lazy(() => import("./pages/ContractPage"));
const PolicyPage = lazy(() => import("./pages/PolicyPage"));
const ClaimsPage = lazy(() => import("./pages/ClaimsPage"));

const routeDictionary: { [id: string]: IRoute } = {
    contracts: { path: "/contracts", title: "Contracts", component: ContractPage },
    policies: { path: "/policies", title: "Policies", component: PolicyPage },
    claims: { path: "/claims", title: "Claims", component: ClaimsPage },
};
const AppRouter = () => {
  return (
      <Routes>
        {Object.keys(routeDictionary).map((key) => {
          const { path, component: Component } = routeDictionary[key];
          return <Route key={key} path={path} element={<Component />} />;
        })}
      </Routes>
  );
};

export default AppRouter;
