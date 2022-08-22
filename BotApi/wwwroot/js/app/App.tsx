import FooterContainer from "@core/footer";
import NavContainer from "@core/navbar";
import "@css/site.scss";
import { IAppState } from "@redux/rootReducer";
import routes from "@routes";
import React from "react";
import { connect } from "react-redux";
import { Route, Switch } from "react-router-dom";
import { Dispatch } from "redux";
import styled, { ThemeProvider } from "styled-components";

const theme = {
  fontSize: "17px"
};

function App() {
  return (
    <ThemeProvider theme={theme}>
      <ContainerRoot>
        <NavContainer />
        <div className="container">
          <Switch>
            {routes.map((route: any, index: number) => {
              return route.component ? (
                <Route
                  key={index}
                  exact={route.exact}
                  path={route.path}
                  render={(data: any) => <route.component {...data} />}
                />
              ) : null;
            })}
          </Switch>
        </div>
        <FooterContainer />
      </ContainerRoot>
    </ThemeProvider>
  );
}

function mapStateToProps(state: IAppState) {
  return {
    location: state.router.location
  };
}

function mapDispatchToProps(dispatch: Dispatch) {
  return {
    dispatch
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(App);

const ContainerRoot = styled.div`
  min-height: 100%;

  display: flex;
  flex-direction: column;
`;
