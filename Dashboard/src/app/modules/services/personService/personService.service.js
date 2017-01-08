export default function personServiceInstance(
	$http
	, $q
) {
	'ngInject';
	const apiUrl = 'http://localhost:53879';
	const personsUrl = `${apiUrl}/CoolPersons`;
	const averageUrl = `${personsUrl}/AverageCoolness`;
	let averageCoolness;
	let personsMap = new Map();
	let personArray = [];

	const serviceInstance = {
		getAverageCoolness,
		getAllPersons
	};
	let activation = activate();

	return serviceInstance;

	function activate() {
		const averageCoolnessRequest = requestAverageCoolness();
		const allPersonsRequest = requestAllPersons();

		return $q.all([
			averageCoolnessRequest,
			allPersonsRequest
		]);
	}

	function getAverageCoolness() {
		return averageCoolness;
	}

	function requestAverageCoolness() {
		$http.get(averageUrl)
		.then(response => {
			averageCoolness = response.data;
		})
	}

	function getAllPersons() {
		return activation.then(() => personArray);
	}

	function requestAllPersons() {
		return $http.get(personsUrl)
		.then(response => {
			response.data.forEach(personData => {
				const person = new Person(personData.Id, personData.FirstName, personData.LastName, personData.Coolness, serviceInstance);
				personsMap.set(person.id, person);
				personArray.push(person);
			});
		});
	}
}

class Person {
	constructor(id, firstName, lastName, coolness, serviceInstance) {
		this.id = id;
		this.firstName = firstName;
		this.lastName = lastName;
		this.coolness = coolness;
		this.serviceInstance = serviceInstance;
	}

	isCool() {
		return this.coolness > this.serviceInstance.getAverageCoolness();
	}
}
