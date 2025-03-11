import { combineReducers } from "redux";
import PolicyTypeReducer from "./PolicyTypes.reducer";

const rootReducer = combineReducers({
  policy: PolicyTypeReducer,
});

export type RootState = ReturnType<typeof rootReducer>;

export default rootReducer;
