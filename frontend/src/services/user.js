import BaseAPI from './api';

class UserService extends BaseAPI {
  createUser = async (payload) => {
    const url = '/users';
    return this.postJson(url, payload);
  }

  getUsers = async () => {
    const url = '/users';
    return this.getJson(url);
  }
}

export default new UserService();
