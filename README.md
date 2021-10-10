# address-project
 
## Usage

1. Install [Docker](https://docs.docker.com/get-docker/) since it's required for doing the docker compose.

2. Replace the `GoogleMapsApiKey` on the appsettings.json file. File should be located inside the backend/AddressProject.WebApi folder

3. Place the terminal on the infrastructure folder and run this command.

```sh
docker compose -p address-project up
```

4. Once the four projects are running, you can navigate the app going to [https://localhost:3000/](https://localhost:3000/) 