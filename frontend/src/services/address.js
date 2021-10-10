import BaseAPI from './api';

class AddressService extends BaseAPI {
  checkAddress = async (payload) => {
    const url = '/addresses';

    return this.postJson(url, payload);
  }
}

export default new AddressService();
