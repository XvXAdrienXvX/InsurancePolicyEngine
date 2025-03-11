import { all } from "redux-saga/effects";
import {watchPolicySaga} from "./Policy.saga"


export default function* rootSaga() {
  yield all([watchPolicySaga()]);
}
