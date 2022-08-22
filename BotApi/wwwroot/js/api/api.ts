async function checkStatus(response: any) {
  if (response?.status >= 200 && response?.status < 300) {
    const data = await response.json();
    return data;
  } else {
    const responseError = await response.json();
    if (Array.isArray(responseError.error)) {
      const errors = responseError.error.map((error: any) => ({
        type: error.type,
        status: error.code,
        message: error.message
      }));
      console.error(errors);
      // throw errors;
    } else {
      console.error(responseError);
      //throw responseError;
    }
  }
}

export default class Api {
  public async get(
    url: string,
    body: any,
    headers: any | undefined = {},
    signal: AbortSignal = null
  ) {
    const query = body;
    const rest: any = undefined;
    const request = new Request(url + query, {
      headers: new Headers({
        Accept: "application/json",
        credentials: "same-origin",
        ...headers,
        ...rest
      })
    });
    try {
      const response = await fetch(request, { signal: signal });
      return checkStatus(response);
    } catch (e) {
      if (e.name === "AbortError") {
        return e.name;
      } else {
        console.error(e);
      }
    }
  }

  public async post(
    url: string,
    body: any = null,
    headers: any | undefined = {}
  ) {
    const rest: any = undefined;
    const request = new Request(url, {
      method: "POST",
      headers: new Headers({
        "Content-Type": "application/json",
        Accept: "application/json",
        ...headers,
        ...rest
      }),
      body: body && JSON.stringify(body)
    });

    const response = await fetch(request).catch((e) => {
      const error = {
        type: "failed",
        status: "failed",
        message: e.message
      };
      throw error;
    });
    return checkStatus(response);
  }

  public async delete(
    url: string,
    body: any = null,
    headers: any | undefined = {}
  ) {
    const rest: any = undefined;
    const request = new Request(url, {
      method: "DELETE",
      headers: new Headers({
        "Content-Type": "application/json",
        Accept: "application/json",
        ...headers,
        ...rest
      }),
      body: body && JSON.stringify(body)
    });

    const response = await fetch(request).catch((e) => {
      const error = {
        type: "failed",
        status: "failed",
        message: e.message
      };
      throw error;
    });
    return checkStatus(response);
  }

  public async put(
    url: string,
    body: any = null,
    headers: any | undefined = {}
  ) {
    const request = new Request(url, {
      method: "PUT",
      headers: new Headers({
        "Content-Type": "application/json",
        Accept: "application/json",
        ...headers
      }),
      body: body && JSON.stringify(body)
    });

    const response: any = await fetch(request).catch((e) => {
      const error = {
        type: "failed",
        status: "failed",
        message: e.message
      };
      throw error;
    });
    return checkStatus(response);
  }

  public async file(
    url: string,
    body: any = null,
    headers: any | undefined = {}
  ) {
    const request = new Request(url, {
      method: "POST",
      headers: new Headers({
        Accept: "application/json",
        ...headers
      }),
      body
    });

    const response = await fetch(request).catch((e) => {
      const error = {
        type: "failed",
        status: "failed",
        message: e.message
      };
      throw error;
    });
    return checkStatus(response);
  }

  async fileDownload(
    url: string,
    body: any = null,
    headers: any | undefined = {}
  ) {
    const request = new Request(url, {
      headers: new Headers({
        Accept: "application/json",
        ...headers
      }),
      body
    });

    const response: any = await fetch(request).catch((e) => {
      return {
        type: e,
        status: 500,
        message: e
      };
    });

    if (response?.status >= 200 && response?.status < 300) {
      const data = await response.blob();
      return data;
    } else {
      // const err = await response.json();
      // const error = {
      //   type: err.type,
      //   status: err.code,
      //   message: err.message
      // }
      const error = {
        status: response.status,
        message: response.statusText
      };
      throw error;
    }
  }

  public async postNoAuth(
    url: any,
    body: any = null,
    headers: any | undefined = {}
  ) {
    const rest: any = undefined;
    const request = new Request(url, {
      method: "POST",
      headers: new Headers({
        "Content-Type": "application/json",
        Accept: "application/json",
        ...headers,
        ...rest
      }),
      body: body && JSON.stringify(body)
    });
    const response = await fetch(request).catch((e) => {
      return { type: e, status: 500, message: e };
    });
    return checkStatus(response);
  }

  public async getNoAuth(url: any, body: any, headers: any | undefined = {}) {
    const rest: any = undefined;
    //const query = queryString(body);
    const query = body;
    const request = new Request(url + query, {
      headers: new Headers({
        ...headers,
        ...rest
      })
    });

    const response = await fetch(request);
    return checkStatus(response);
  }

  public async delNoAuth(
    url: any,
    body: any = null,
    headers: any | undefined = {}
  ) {
    const rest: any = undefined;
    const request = new Request(url, {
      method: "DELETE",
      headers: new Headers({
        "Content-Type": "application/json",
        Accept: "application/json",
        ...headers,
        ...rest
      }),
      body: body && JSON.stringify(body)
    });
    const response = await fetch(request).catch((e) => {
      return { type: e, status: 500, message: e };
    });
    return checkStatus(response);
  }

  public async download(url: string, fileName: any, mime: any) {
    const request = new Request(url, {
      method: "GET",
      headers: new Headers({
        credentials: "same-origin"
      })
    });

    const response: any = await fetch(request).catch((e) => {
      return {
        type: e,
        status: 500,
        message: e
      };
    });

    if (response?.status >= 200 && response?.status < 300) {
      const blob = await response.blob();

      return { success: true };
    } else {
      const error = {
        status: response.status,
        message: response.statusText
      };
      throw error;
    }
  }

  public async downloadGeneric(url: string, body: any = null) {
    const request = new Request(url, {
      method: "POST",
      headers: new Headers({
        "Content-Type": "application/json",
        Accept: "application/json"
      }),
      body: body && JSON.stringify(body)
    });

    const response: any = await fetch(request).catch((e) => {
      return {
        type: e,
        status: 500,
        message: e
      };
    });
    if (response?.status >= 200 && response?.status < 300) {
      return { response: response, headers: response.headers };
    } else {
      const error = {
        status: response.status,
        message: response.statusText
      };
      throw error;
    }
  }
}
