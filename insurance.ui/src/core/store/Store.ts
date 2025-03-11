import createSagaMiddleware from "redux-saga";
import rootReducer from "../reducers/RootReducer";
import rootSaga from "../sagas/RootSaga";
import { configureStore } from "@reduxjs/toolkit";

const sagaMiddleware = createSagaMiddleware();

// Create Redux store with rootReducer and saga middleware using configureStore
export const store = configureStore({
  reducer: rootReducer,
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(sagaMiddleware), // Add saga middleware to the default middleware
});

sagaMiddleware.run(rootSaga);

export type AppDispatch = typeof store.dispatch;  // Type for dispatch function
export type RootState = ReturnType<typeof store.getState>;  