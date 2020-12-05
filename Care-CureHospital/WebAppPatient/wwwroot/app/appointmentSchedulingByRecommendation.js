Vue.component("appointmentSchedulingByRecommendation", {
	data: function () {
		return {
            recommendationStep : 1,
            state : {
                disabledDates: {
                    to: new Date(),
                }
            },
            startDateModel : '',
            endDateModel : '',
            specialization : '0',
            doctors : '0',
            priority : '0',
            selectedAppointment: null,
            specializations: [],
            doctorsBySpecialization : []
		}
	},
	template: `
	<div>
	
		<div class="boundary-for-scroll-appointment-scheduling-by-recommendation">
			<div class="logo-and-name-appointment-scheduling-by-recommendation">
					<div class="logo-appointment-scheduling-by-recommendation">        
						<img src="images/hospital.png"/>
					</div>
					<div class="web-name-appointment-scheduling-by-recommendation">
						<h3></h3>
					</div>  
				</div>
	 
				<div class="main-appointment-scheduling-by-recommendation">     
					<ul class="menu-contents">
					<li class="active"><a href="#/">Termini za pregled</a></li>
					</ul>
				</div>
 
				<div class="dropdown">
					<button class="dropbtn">
						<img id="menuIcon" src="images/menuIcon.png" />
						<img id="userIcon" src="images/user.png" />
					</button>
				<div class="dropdown-content">
					<a  href="#/patientRegistration">Registruj se</a>
					<a>Prijavi se</a>
				</div>
			</div>
		</div>
	 
	<div class="form-for-appointment-scheduling-by-recommendation">
        <div class="form-title-appointment-scheduling-by-recommendation">
            <div v-if="this.recommendationStep === 1">
                <h1>Vremenski period termina</h1>
                <h3>Izaberite datum od:</h3>
                <vuejs-datepicker v-model="startDateModel" id="startDateID" name="startDate" type="date"  format="dd.MM.yyyy." :disabledDates="state.disabledDates" placeholder="Izaberite datum od..." ></vuejs-datepicker><br>
                <h3>Izaberite datum do:</h3>
                <vuejs-datepicker v-model="endDateModel" id="endDateID" name="endDate" type="date"  format="dd.MM.yyyy."  :open-date="startDateModel" :disabledDates="newDateStart" v-bind:disabled="startDateModel === ''" placeholder="Izaberite datum do..." ></vuejs-datepicker>
                <div class="next-btn-appointment-scheduling-by-recommendation">
                    <button type="button" @click="nextRecommendationStep()">Dalje</button>
                </div>
            </div>
            <div v-if="this.recommendationStep === 2">
                <h1 style="padding-bottom: 70px;">Specijalizacija</h1>
                <h3>Izaberite specijalističku granu:</h3>
                <select v-model="specialization" >
                    <option value="0">Izaberite specijalističku granu...</option>
                    <option v-for="s in this.specializations" :key="s.id" :value="s.id">{{ s.specialitationForDoctor }}</option>
                </select><br>
                <div class="next-btn-appointment-scheduling-by-recommendation">
                    <button type="button" @click="nextRecommendationStep()" style="margin-top: 80%;">Dalje</button>
                </div>
                <div class="back-btn-appointment-scheduling-by-recommendation">
                    <button type="button" @click="backRecommendationStep()">Nazad</button>
                </div>
            </div>
            <div v-if="this.recommendationStep === 3">
                <h1 style="padding-bottom: 70px;">Doktor</h1>
                <h3>Izaberite doktora:</h3>
                <select v-model="doctors">
                    <option value="0">Izaberite doktora...</option>
                    <option v-for="d in this.doctorsBySpecialization" :key="d.id" :value="d.id">Dr {{ d.name }} {{d.surname}}</option>
                </select><br>
                <div class="next-btn-appointment-scheduling-by-recommendation">
                    <button type="button" @click="nextRecommendationStep()" style="margin-top: 80%;">Dalje</button>
                </div>
                <div class="back-btn-appointment-scheduling-by-recommendation">
                    <button type="button" @click="backRecommendationStep()">Nazad</button>
                </div>
            </div>
            <div v-if="this.recommendationStep === 4">
                <h1 style="padding-bottom: 70px;">Prioritet</h1>
                <h3>Izaberite prioritet:</h3>
                <select v-model="priority">
                    <option value="0">Izaberite prioritet...</option>
                    <option value="1">Doktor</option>
                    <option value="2">Vremenski period</option>
                </select><br>
                <div class="next-btn-appointment-scheduling-by-recommendation">
                    <button type="button" @click="nextRecommendationStep()" style="margin-top: 80%;">Dalje</button>
                </div>
                <div class="back-btn-appointment-scheduling-by-recommendation">
                    <button type="button" @click="backRecommendationStep()">Nazad</button>
                </div>
            </div>
            <div v-if="this.recommendationStep === 5">
                <h1 style="padding-bottom: 30px;" v-if="this.priority === '1'">Preporučeni termini po doktoru</h1>
                <h1 style="padding-bottom: 30px;" v-if="this.priority === '2'">Preporučeni termini po vremenskom periodu</h1>
                <h3>Izaberite jedan slobodan termin:</h3><br>
                <div class="scroll-in-appointment-scheduling-by-recommendation">
                    <div class="table-wrapper-appointment-scheduling-by-recommendation">
                        <table class="fl-table-appointment-scheduling-by-recommendation">
                            <thead>
                            <tr>
                                <th>Doktor</th>
                                <th>Specijalistička grana</th>
                                <th>Datum</th>
                                <th>Vreme</th>
                                <th>Izaberite</th>
                            </tr>
                            </thead>
                            <tbody>        
                                <tr>
                                    <td>Dr. Milan Milanovic</td>
                                    <td>Kardiolog</td>
                                    <td>12.12.2020.</td>
                                    <td>11:00-11:30</td>
                                    <td><input v-model="selectedAppointment" type="radio" name="radioButtonAppointment" value="1"></td>		                        	                 
                                </tr>
                                <tr>
                                    <td>Dr. Milan Milanovic</td>
                                    <td>Kardiolog</td>
                                    <td>12.12.2020.</td>
                                    <td>12:00-12:30</td>
                                    <td><input v-model="selectedAppointment" type="radio" name="radioButtonAppointment" value="2"></td>		                        	                 
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="next-btn-appointment-scheduling-by-recommendation">
                    <button type="button" @click="scheduleTerm()" style="margin-top: 8%;">Zakaži</button>
                </div>
                <div class="back-btn-appointment-scheduling-by-recommendation" style="margin-top: -20.8%;">
                    <button type="button" @click="backRecommendationStep()">Nazad</button>
                </div>
            </div>
        </div>
    </div>

	 <div class="verticalLinePublishFeedback"></div>
	
	 <div class="sideComponents">      
	     <ul class="ulForSideComponents">
			<div><li><a href="#/">Obično zakazivanje</a></li></div><br/>
		    <div><li class="active"><a href="#/appointmentSchedulingByRecommendation">Preporuka termina</a></li></div><br/>
	     </ul>
	 </div>
	 	  
	</div>
        
    `   
    ,
	components : {
		vuejsDatepicker
    }
    ,
    computed : {	
		newDateStart() { 		
			if(this.startDateModel !== ''){
				return {
		            to: moment(this.startDateModel).startOf('day').add(1, 'days').toDate()
		        }
            }
		}		
	},
	methods: {
        nextRecommendationStep : function() {
            if(this.recommendationStep === 1 && this.startDateModel !== '' && this.endDateModel !== ''){
                if(moment(this.endDateModel).toDate() < moment(this.startDateModel).toDate()){
                    this.startDateModel = this.endDateModel;
                    toast('Kranji datum mora biti veći ili jednak početnom datumu')
                } else if(this.recommendationStep === 1) {
                    this.recommendationStep += 1;
                } 
            }else if(this.recommendationStep === 2 && this.specialization !== '0'){
                this.recommendationStep += 1;
                axios.get('api/appointment/getAllDoctorBySpecializationId/' + this.specialization).then(response => {
                    this.doctorsBySpecialization = response.data;
                });
            } else if (this.recommendationStep === 3 && this.doctors !== '0') {
                this.recommendationStep += 1;
            }else if(this.recommendationStep === 4 && this.priority !== '0'){
                this.recommendationStep += 1;
            }         
        },
        backRecommendationStep : function() {
            if(this.recommendationStep >= 2) {
                this.recommendationStep -= 1;
            }
        },
        scheduleTerm : function() {
            if(this.selectedAppointment === null){
                toast('Morate selektovati neki od ponuđenih termina')
            } else {
                this.resetData()
                toast('Termin je uspešno rezervisan!')
            }
        },
        resetData : function(){
            this.recommendationStep = 1;
            this.startDateModel = '';
            this.endDateModel = '';
            this.specialization = '0';
            this.doctors = '0';
            this.priority = '0';
            this.selectedAppointment = null;
        }
	},
	mounted() {
        axios.get('api/appointment/getAllSpecialization').then(response => {
            this.specializations = response.data;
        });
	}

});