const getApiURL = () => process.env.REACT_APP_API_URL;

const buildJsonHeaders = () => ({ 'Content-Type': 'application/json', Accept: 'application/json' });

export default class BaseAPI {
  constructor() {
    this.apiBaseURL = getApiURL();
    this.headers = buildJsonHeaders();
  }

  makeHttpRequest = async (url, opts) => fetch(this.apiBaseURL + url, opts)
    .then((response) => {
      if (response.ok) {
        return Promise.resolve(response);
      }
      return Promise.reject(response);
    })

  getJson = async (url) => {
    const opts = {
      method: 'GET',
      headers: this.headers,
    };

    return new Promise((resolve, reject) => {
      this.makeHttpRequest(url, opts)
        .then((response) => {
          resolve(response);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  postJson = async (url, content) => {
    const opts = {
      method: 'POST',
      headers: this.headers,
      body: JSON.stringify(content),
    };

    return new Promise((resolve, reject) => {
      this.makeHttpRequest(url, opts)
        .then((response) => {
          resolve(response);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
}
