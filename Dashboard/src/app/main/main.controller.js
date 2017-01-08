export class MainController {
	constructor (
		personService	
		, $log
	) {
    'ngInject';

    this.personService = personService;
    this.$log = $log;
    this.activate();
  }

	activate() {
		this.personService.getAllPersons().then(persons => {
			this.persons = persons;
		})
  }
}
