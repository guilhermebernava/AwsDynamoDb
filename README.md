# AWS DynamoDB Product API

Manage products with ease using this CRUD (Create, Read, Update, Delete) API powered by Amazon DynamoDB as the underlying database. To get started, follow the steps below to configure your AWS CLI profile and integrate it with the `appsettings.json` file.

## Prerequisites

Before you begin, ensure you have the following prerequisites installed:

1. [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
2. [AWS Command Line Interface (CLI)](https://aws.amazon.com/cli/)

## Configuration

### 1. AWS CLI Configuration

Follow these steps to configure your AWS CLI profile:

1. Install the AWS CLI by referring to the [official installation guide](https://docs.aws.amazon.com/cli/latest/userguide/cli-configure-files.html).

2. Open your terminal or command prompt and run the following command, replacing `your-profile-name` with your chosen AWS profile name:

   ```bash
   aws configure --profile your-profile-name
   ```

3. You'll be prompted to provide your AWS Access Key ID, AWS Secret Access Key, default region name, and output format. Enter the required information based on your AWS account setup.

### 2. `appsettings.json` Configuration

In the `appsettings.json` file of the API project, include your AWS profile name as follows:

```json
{
  "AWS": {
    "Profile": "your-profile-name",
    "Region": "your-aws-region"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  // Other settings...
}
```

Replace `"your-profile-name"` with the AWS profile name you configured in the AWS CLI, and set `"your-aws-region"` to your preferred AWS region (e.g., `"us-east-1"`).

## Running the API

To run the API locally, follow these steps:

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/your-repo-url/aws-dynamodb-product-api.git
   ```

2. Navigate to the project directory:

   ```bash
   cd aws-dynamodb-product-api
   ```

3. Build and run the API using the .NET CLI:

   ```bash
   dotnet run
   ```

The API will be accessible locally at `http://localhost:5000` or `https://localhost:5001`.

## API Endpoints

Explore the following API endpoints:

- **GET /api/product**: Retrieve a list of all products.
- **POST /api/product**: Create a new product.
- **PUT /api/product**: Update an existing product by ID.
- **DELETE /api/product**: Delete a product by ID.
