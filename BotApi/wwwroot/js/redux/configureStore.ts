import { createStore, applyMiddleware, compose } from "redux";
import createSagaMiddleware, { END } from "redux-saga";
import rootReducer from "./rootReducer";
import { routerMiddleware } from "connected-react-router";
import rootSaga from "@redux/sagas";

export default function configureStore(initialState: any, history: any) {
  const sagaMiddleware = createSagaMiddleware({
    onError: (e) => {
      console.log("Global saga error handler", e);
    }
  });

  const composeSetup =
    process.env.NODE_ENV !== "production" &&
    typeof window === "object" &&
    (window as any).__REDUX_DEVTOOLS_EXTENSION_COMPOSE__
      ? (window as any).__REDUX_DEVTOOLS_EXTENSION_COMPOSE__
      : compose;

  const store = createStore(
    rootReducer(history),
    initialState,
    composeSetup(applyMiddleware(sagaMiddleware, routerMiddleware(history)))
  );

  if (module.hot) {
    module.hot.accept("./rootReducer", () => {
      const nextRootReducer = require("./rootReducer").default(history);
      store.replaceReducer(nextRootReducer);
    });
  }
  sagaMiddleware.run(rootSaga);

  (store as any).close = () => store.dispatch(END);
  return store;
}
