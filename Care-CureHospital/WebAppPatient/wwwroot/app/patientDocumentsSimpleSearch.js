Vue.component("patientDocumentsSimpleSearch", {
	data: function () {
		return {
			patientDocuments: [],
			firstSearchParams: 'Doktoru',
			firstInput: '',
			publishingDate: '',
			firstResult: [],
			reportsButtonSelected : true,
			prescriptionsButtonSelected : false,
			reportsResult: [],
			prescriptionsResult : []
		}
	},
	template: `
	<div>
	
	 <div class="boundaryForScroll">
	     <div class="logoAndName">
	         <div class="logo">        
	             <img src="pictures/clinic.png"/>
	         </div>
	         <div class="webName">
	             <h3></h3>
	         </div>  
	     </div>
	 
	     <div class="main">     
	         <ul class="menu-contents">
	            <li  class="active"><a href="#/patientDocumentsSimpleSearch">Pretraga dokumenata</a></li>
	         </ul>
	     </div>
 
	     <div class="dropdown">
	        <button class="dropbtn">
	        	<img id="menuIcon" src="pictures/menuIcon.png" />
	        	<img id="userIcon" src="pictures/user.png" />
	        </button>
		    <div class="dropdown-content">
		        <a href="#/patientRegistration">Registruj se</a>
	            <a>Prijavi se</a>
		    </div>
	    </div>
	 </div>	

	<div class="patients-docs-simple-search">
            <div class="form-title-search">
				<h1>Pretraži po:</h1>

				<div class="reports-btn" v-if="this.reportsButtonSelected === true">
					<button type="button" @click="reportsSearchButton" style="background-color:#054f5294">Izveštaji</button>
				</div>
				<div class="reports-btn" v-if="this.reportsButtonSelected === false">
					<button type="button" @click="reportsSearchButton">Izveštaji</button>
				</div>
				<div class="prescriptions-btn" v-if="this.prescriptionsButtonSelected === true">
					<button type="button" @click="prescriptionsSearchButton" style="background-color:#054f5294">Recepti</button>
				</div>
				<div class="prescriptions-btn" v-if="this.prescriptionsButtonSelected === false">
					<button type="button" @click="prescriptionsSearchButton">Recepti</button>
				</div>

				
				<select v-if="this.reportsButtonSelected === true" v-model="firstSearchParams" name="firstRow" style="width:160px">
					<option value="Doktoru" selected>Doktoru</option>
					<option value="Datumu">Datumu</option>
					<option value="Sadržaju">Sadržaju</option>
					<option value="Sobi">Sobi</option>
				</select>
				
				<select v-if="this.prescriptionsButtonSelected === true" v-model="firstSearchParams" name="firstRow" style="width:160px">
					<option value="Doktoru" selected>Doktoru</option>
					<option value="Datumu">Datumu</option>
					<option value="Sadržaju">Sadržaju</option>
					<option value="Lekovima">Lekovima</option>
				</select>
                			
				<input v-model="publishingDate" v-if="firstSearchParams === 'Datumu'" type="date" format="dd.MM.yyyy." style="width:250px; height:42px">
				<!--<vuejs-datepicker v-if="firstSearchParams === 'Datumu'"></vuejs-datepicker>-->
				
				<input v-else v-model="firstInput" type="text" style="width:250px" placeholder="">

				<div class="search-btn">
					<button type="button" @click="simpleSearch()" style="margin-top:3%">Potvrdi</button>
				</div>

		    </div>
     </div>
	 
	 <div class="verticalLine"></div>
	
	 <div class="sideComponents">      
	     <ul class="ulForSideComponents">
			<div><li class="active"><a>Obična</a></li></div><br/>
		    <div><li><a href="#/patientDocumentsAdvancedSearch">Napredna</a></li></div><br/>
	     </ul>
	 </div>
				  
	<template v-if="this.reportsButtonSelected === true">
		<div class="listOfReports">		 
			<div v-for="report in reportsResult" >		 
					<div class="wrapper-reports">
						<div class="report-img">
							<img src="./pictures/comment.png" height="150" width="150" style="margin-left: 20%; margin-top: 14%;">
						</div>
						<div class="report-info">
							<div class="report-text">
								<h1>Izveštaj od doktora: {{report.doctor}}</h1>
								<h3>Soba: {{report.room}}</h3>			
								<p>{{report.publishingDate}}</p>
								<div  style="overflow-y:scroll;height:90px;width:400px;border:1px solid;padding: 5px 5px 10px 5px">
									{{report.comment}}
								</div>
								<div class="reviewReport-btn">
										<button type="button" @click="">Prikaži</button>
								</div>
							</div>
						</div>		
					</div>
			</div>
		</div>
	</template>

	<template v-if="this.prescriptionsButtonSelected === true">
		<div class="listOfReports">		 
			<div v-for="prescription in prescriptionsResult" >		 
				<div class="wrapper-reports">
					<div class="report-img">
						<img src="./pictures/comment.png" height="150" width="150" style="margin-left: 20%; margin-top: 14%;">
					</div>
					<div class="report-info">
						<div class="report-text">
							<h1>Recept od doktora: {{prescription.doctor}}</h1></br>		
							<p>{{prescription.publishingDate}}</p>
							<div  style="overflow-y:scroll;height:90px;width:400px;border:1px solid;padding: 5px 5px 10px 5px">
								{{prescription.comment}}
							</div>
							<div class="reviewReport-btn">
									<button type="button" @click="">Prikaži</button>
							</div>
						</div>
					</div>		
				</div>
			</div>
		</div>
	</template>
	
	<!--
	<template v-if="!patientFeedbacks || !patientFeedbacks.length"> 
		<div  class="emptyListOfFeedbacks">
			<h2 >Trenutno nema utisaka pacijenata!</h2>
		</div>
	</template >
	-->
			     	  
	</div>
        
	`
	,
	methods: {
		simpleSearch: function () {
			if (this.reportsButtonSelected === true) {
				if (this.firstSearchParams === 'Doktoru') {
					if (this.firstInput === '') {
						this.reportsResult = this.reportsForPatient
						return
					}
					axios.get('api/medicalExaminationReport/findReportsByDoctor', {
						params: {
							patientId: 1,
							doctor: this.firstInput
						}
					}).then(response => {
						this.reportsResult = response.data;
					});
				} else if (this.firstSearchParams === 'Datumu') {
					if (this.publishingDate === '') {
						this.reportsResult = this.reportsForPatient
						return
					}
					axios.get('api/medicalExaminationReport/findReportsByDate', {
						params: {
							patientId: 1,
							date: this.publishingDate
						}
					}).then(response => {
						this.reportsResult = response.data;
					});
				} else if (this.firstSearchParams === 'Sadržaju') {
					if (this.firstInput === '') {
						this.reportsResult = this.reportsForPatient
						return
					}
					axios.get('api/medicalExaminationReport/findReportsByComment', {
						params: {
							patientId: 1,
							comment: this.firstInput
						}
					}).then(response => {
						this.reportsResult = response.data;
					});
				} else if (this.firstSearchParams === 'Sobi') {
					if (this.firstInput === '') {
						this.reportsResult = this.reportsForPatient
						return
					}
					axios.get('api/medicalExaminationReport/findReportsByRoom', {
						params: {
							patientId: 1,
							room: this.firstInput
						}
					}).then(response => {
						this.reportsResult = response.data;
					});
				}
			} else if (this.prescriptionsButtonSelected === true) {
				if (this.firstSearchParams === 'Doktoru') {
					if (this.firstInput === '') {
						this.prescriptionsResult = this.prescriptionsForPatient
						return
					}
					axios.get('api/prescription/findPrescriptionsByDoctor', {
						params: {
							patientId: 1,
							doctor: this.firstInput
						}
					}).then(response => {
						this.prescriptionsResult = response.data;
					});
				} else if (this.firstSearchParams === 'Datumu') {
					if (this.publishingDate === '') {
						this.prescriptionsResult = this.prescriptionsForPatient
						return
					}
					axios.get('api/prescription/findPrescriptionsByDate', {
						params: {
							patientId: 1,
							date: this.publishingDate
						}
					}).then(response => {
						this.prescriptionsResult = response.data;
					});
				} else if (this.firstSearchParams === 'Sadržaju') {
					if (this.firstInput === '') {
						this.prescriptionsResult = this.prescriptionsForPatient
						return
					}
					axios.get('api/prescription/findPrescriptionsByComment', {
						params: {
							patientId: 1,
							comment: this.firstInput
						}
					}).then(response => {
						this.prescriptionsResult = response.data;
					});
				} else if (this.firstSearchParams === 'Lekovima') {
					if (this.firstInput === '') {
						this.prescriptionsResult = this.prescriptionsForPatient
						return
					}
					axios.get('api/prescription/findPrescriptionsByMedicaments', {
						params: {
							patientId: 1,
							medicaments: this.firstInput
						}
					}).then(response => {
						this.prescriptionsResult = response.data;
					});
				}
            }
		},

		reportsSearchButton: function () {
			this.prescriptionsButtonSelected = false;
			this.reportsButtonSelected = true;	
			this.firstSearchParams = 'Doktoru',				
			this.firstInput = '',				
			this.publishingDate = '',
			this.reportsResult = this.reportsForPatient
		},

		prescriptionsSearchButton: function () {
			this.reportsButtonSelected = false;	
			this.prescriptionsButtonSelected = true;
			this.firstSearchParams = 'Doktoru',
			this.firstInput = '',
			this.publishingDate = '',
			this.prescriptionsResult = this.prescriptionsForPatient
		}
	},
	computed: {

	},
	mounted() {
		axios.get('api/medicalExaminationReport/getForPatient/' + 1).then(response => {
			this.reportsForPatient = response.data;
			this.reportsResult = this.reportsForPatient;
		});
		axios.get('api/prescription/getForPatient/' + 1).then(response => {
			this.prescriptionsForPatient = response.data;
			this.prescriptionsResult = this.prescriptionsForPatient;
		});
	}
});