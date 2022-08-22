import App from "@app/App";
import { GlobalStyles } from "@app/global-styles";
import configureStore from "@redux/configureStore";
import { ConnectedRouter } from "connected-react-router";
import { createHashHistory } from "history";
import React from "react";
import ReactDOM from "react-dom";
import type {} from "styled-components/cssprop";
import { Provider } from "react-redux";

const initialState = {};
const history = createHashHistory();
const store = configureStore(initialState, history);

ReactDOM.render(
  <React.StrictMode>
    <GlobalStyles />
    <Provider store={store}>
      <ConnectedRouter history={history}>
        <App />
      </ConnectedRouter>
    </Provider>
    {/* <TelegramLoginButton
      botName="simostest_bot"
      dataOnauth={(us: TelegramUser) => console.log(us)}
    /> */}
  </React.StrictMode>,

  document.getElementById("root")
);
