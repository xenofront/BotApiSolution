import { call } from "redux-saga/effects";

export function* logError(model: any) {
  yield call(logErrorApi, model);
}

function logErrorApi(exception: any) {
  console.error(exception);
}
