const path = require("path");
const FileSync = require('lowdb/adapters/FileSync');
const fs = require('fs');
const low = require('lowdb');

function seed(connectivityPath) {
  const apiPath = path.dirname(connectivityPath);

  const seedFile = path.join(apiPath, "nswag-seed.json");
  const databaseFile = path.join(apiPath, "nswag.json");

  const adapter = new FileSync(databaseFile);
  const db = low(adapter);

  const nswagData = JSON.parse(
    fs.readFileSync(seedFile, "utf-8")
  );

  db.setState(nswagData).write();

  console.log("nswag.json generated successfully.");
}

function convert(connectivityPath) {
  const apiPath = path.dirname(connectivityPath);

  const pathToYaml = connectivityPath;
  const pathToJson = path.join(apiPath, "nswag.json");
  const adapter = new FileSync(pathToJson);
  const db = low(adapter);

  try {
    console.log(`Load '${pathToYaml}'`);
    const doc = fs.readFileSync(pathToYaml, 'utf8');
    console.log(`Write to '${pathToJson}'`);
    db.set("documentGenerator.fromDocument.json", doc).write();
  } catch (e) {
    console.log(e);
  }
}

function main() {

  for (let j = 2; j < process.argv.length; j++) {
    const connectivityPath = process.argv[j];
    seed(connectivityPath);
    convert(connectivityPath);
  }
}

if (require.main === module) {
  main();
}
