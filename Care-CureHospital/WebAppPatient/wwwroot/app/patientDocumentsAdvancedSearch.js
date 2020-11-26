Vue.component("patientDocumentsAdvancedSearch", {
	data: function () {
		return {
			reportsForPatient: [],
			prescriptionsForPatient : [],
			firstSearchParams: 'Doktoru',
			secondSearchParams: 'Doktoru',
			thirdSearchParams: 'Doktoru',
			fourthSearchParams: 'Doktoru',
			firstLogicOperators: 'I',
			secondLogicOperators: 'I',
			thirdLogicOperators: 'I',
			fourthLogicOperators: 'I',
			count: 0,
			firstInput: '',
			secondInput: '',
			thirdInput: '',
			fourthInput: '',
			firstPublishingDate: '',
			secondPublishingDate: '',
			thirdPublishingDate: '',
			fourthPublishingDate: '',
			firstResult: [],
			secondResult: [],
			thirdResult: [],
			fourthResult: [],
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
	            <li  class="active"><a href="#/patientDocumentsAdvancedSearch">Pretraga dokumenata</a></li>
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

	<div class="filterReports">
            <div class="form-title">
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

                <select v-if="this.reportsButtonSelected === true" v-model="firstSearchParams" name="firstRow">
					<option value="Doktoru" selected>Doktoru</option>
					<option value="Datumu">Datumu</option>
					<option value="Sadržaju">Sadržaju</option>
					<option value="Sobi">Sobi</option>
				</select>
				<select v-if="this.prescriptionsButtonSelected === true" v-model="firstSearchParams" name="firstRow">
					<option value="Doktoru" selected>Doktoru</option>
					<option value="Datumu">Datumu</option>
					<option value="Sadržaju">Sadržaju</option>
					<option value="Lekovima">Lekovima</option>
				</select>

				<input v-if="firstSearchParams === 'Datumu'" v-model="firstPublishingDate" type="date" style="width:150px;height:42px">
				<input v-else v-model="firstInput" type="text" style="width:150px" placeholder="">

				<select v-model="firstLogicOperators" style="width:90px" name="firstRow">
					<option value="I" selected>I</option>
					<option value="ILI">ILI</option>
				</select>

				<div v-if="this.count === 0" class="add-param-btn">
                	<button type="button" @click="add">+</button>
				</div>
				<div v-if="this.count >= 1" class="add-param-btn">
                	<button type="button" @click="dec">-</button>
				</div>
									
				<div v-if="this.count >= 1" class="second-row" name="secondRow">
					<select v-model="secondSearchParams">
						<option value="Doktoru" selected>Doktoru</option>
						<option value="Datumu">Datumu</option>
						<option value="Sobi">Sobi</option>
						<option value="Sadržaju">Sadržaju</option>
					</select>

					<input v-if="secondSearchParams === 'Datumu'" v-model="secondPublishingDate" type="date" style="width:150px;height:42px">
					<input v-else v-model="secondInput" type="text" style="width:150px" placeholder="">

					<select v-model="secondLogicOperators" style="width:90px" name="secondRow">
						<option value="I" selected>I</option>
						<option value="ILI">ILI</option>
					</select>

					<div v-if="this.count == 1" class="add-param-btn">
						<button type="button" @click="add">+</button>
					</div>
					<div v-if="this.count >= 2" class="add-param-btn">
                		<button type="button" @click="dec">-</button>
					</div>
				</div>

				<div v-if="this.count >= 2" class="third-row">
					<select v-model="thirdSearchParams">
						<option value="Doktoru" selected>Doktoru</option>
						<option value="Datumu">Datumu</option>
						<option value="Sobi">Sobi</option>
						<option value="Sadržaju">Sadržaju</option>
					</select>

					<input v-if="thirdSearchParams === 'Datumu'" v-model="thirdPublishingDate" type="date" style="width:150px;height:42px">
					<input v-else v-model="thirdInput" type="text" style="width:150px" placeholder="">

					<select v-model="thirdLogicOperators" style="width:90px">
						<option value="I" selected>I</option>
						<option value="ILI">ILI</option>
					</select>

					<div v-if="this.count == 2" class="add-param-btn">
						<button type="button" @click="add">+</button>
					</div>
					<div v-if="this.count >= 3" class="add-param-btn">
                		<button type="button" @click="dec">-</button>
					</div>
				</div>

				<div v-if="this.count >= 3" class="fourth-row">
					<select v-model="fourthSearchParams">
						<option value="Doktoru" selected>Doktoru</option>
						<option value="Datumu">Datumu</option>
						<option value="Sobi">Sobi</option>
						<option value="Sadržaju">Sadržaju</option>
					</select>

					<input v-if="fourthSearchParams === 'Datumu'" v-model="fourthPublishingDate" type="date" style="width:150px;height:42px">
					<input v-else v-model="fourthInput" type="text" style="width:150px" placeholder="">
				
					<div v-if="this.count == 3" class="add-param-btn">
						<button type="button" @click="dec">-</button>
					</div>
				</div>

				<div class="search-btn">
					<button type="button" @click="advancedSeacrh()">Potvrdi</button>
				</div>

		    </div>
     </div>
	 
	 <div class="verticalLine"></div>
	
	 <div class="sideComponents">      
	     <ul class="ulForSideComponents">
			<div><li><a href="#/patientDocumentsSimpleSearch">Obična</a></li></div><br/>
		    <div><li class="active"><a href="#/patientDocumentsAdvancedSearch">Napredna</a></li></div><br/>
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
		advancedSearch: function () {
			
		},

		add: function () {
			this.count += 1
		},

		dec: function () {
			this.count -= 1
		},

		reportsSearchButton: function () {
			this.prescriptionsButtonSelected = false;
			this.reportsButtonSelected = true;	
			this.count = 0,
			this.firstSearchParams = 'Doktoru',
			this.secondSearchParams = 'Doktoru',
			this.thirdSearchParams = 'Doktoru',
			this.fourthSearchParams = 'Doktoru',
			this.firstLogicOperators = 'I',
			this.secondLogicOperators = 'I',
			this.thirdLogicOperators = 'I',
			this.fourthLogicOperators = 'I',
			this.firstInput = '',
			this.secondInput = '',
			this.thirdInput = '',
			this.fourthInput = '',
			this.firstPublishingDate = '',
			this.secondPublishingDate = '',
			this.thirdPublishingDate = '',
			this.fourthPublishingDate = '',
			this.reportsResult = this.reportsForPatient
		},

		prescriptionsSearchButton: function () {
			this.reportsButtonSelected = false;	
			this.prescriptionsButtonSelected = true;
			this.count = 0,
			this.firstSearchParams = 'Doktoru',
			this.secondSearchParams = 'Doktoru',
			this.thirdSearchParams = 'Doktoru',
			this.fourthSearchParams = 'Doktoru',
			this.firstLogicOperators = 'I',
			this.secondLogicOperators = 'I',
			this.thirdLogicOperators = 'I',
			this.fourthLogicOperators = 'I',
			this.firstInput = '',
			this.secondInput = '',
			this.thirdInput = '',
			this.fourthInput = '',
			this.firstPublishingDate = '',
			this.secondPublishingDate = '',
			this.thirdPublishingDate = '',
			this.fourthPublishingDate = '',
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