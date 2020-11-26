Vue.component("surveyAfterExamination", {
	data: function () {
		return {
			listOfQuestions: [],
			commentSurvey: '',
			textOfQuestion1: '',
			gradeOfQuestion1: null,
			poor1: false,
			fair1: false,
			good1: false,
			veryGood1: false,
			excellent1: false,

			textOfQuestion2: '',
			gradeOfQuestion2: null,
			poor2: false,
			fair2: false,
			good2: false,
			veryGood2: false,
			excellent2: false,

			textOfQuestion3: '',
			gradeOfQuestion3: null,
			poor3: false,
			fair3: false,
			good3: false,
			veryGood3: false,
			excellent3: false,

			textOfQuestion4: '',
			gradeOfQuestion4: null,
			poor4: false,
			fair4: false,
			good4: false,
			veryGood4: false,
			excellent4: false,

			textOfQuestion5: '',
			gradeOfQuestion5: null,
			poor5: false,
			fair5: false,
			good5: false,
			veryGood5: false,
			excellent5: false,

			textOfQuestion6: '',
			gradeOfQuestion6: null,
			poor6: false,
			fair6: false,
			good6: false,
			veryGood6: false,
			excellent6: false,

			textOfQuestion7: '',
			gradeOfQuestion7: null,
			poor7: false,
			fair7: false,
			good7: false,
			veryGood7: false,
			excellent7: false,

			textOfQuestion8: '',
			gradeOfQuestion8: null,
			poor8: false,
			fair8: false,
			good8: false,
			veryGood8: false,
			excellent8: false,

			textOfQuestion9: '',
			gradeOfQuestion9: null,
			poor9: false,
			fair9: false,
			good9: false,
			veryGood9: false,
			excellent9: false

		}
	},
	template: `
	<div>
	
	<div class="boundaryForScrollSurvey">
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
				<li><a href="#/">Pretraga dokumenata</a></li>
				<li class="active"><a href="#/">Anketa</a></li>
	         </ul>
	     </div>
 
	     <div class="dropdown">
	        <button class="dropbtn">
	        	<img id="menuIcon" src="pictures/menuIcon.png" />
	        	<img id="userIcon" src="pictures/user.png" />
	        </button>
		    <div class="dropdown-content">
		        <a >Registruj se</a>
	            <a >Prijavi se</a>
		    </div>
		</div>
		
	<div class="survey-vertical-line"></div>
	
	 <div class="sideComponents">      
	     <ul class="ulForSideComponents">
			
	     </ul>
	 </div>

	
	<div class="survey-questions">	
		<h3 class = "doctor-qestions-title">Pitanja o doktoru kod kog je izvršen pregled:</h3> 
		<table class="questions-about-doctor">
			<tr>
			<th style="min-width:530px;">Pitanja</th>
			<th style="min-width:90px;">Vrlo loše</th>
			<th style="min-width:90px;">Loše</th>
			<th style="min-width:90px;">Dobro</th>
			<th style="min-width:90px;">Vrlo dobro</th>
			<th style="min-width:90px;">Odlično</th>
			</tr>
			<tr>
			<td v-model="textOfQuestion1">Ljubaznost doktora prema pacijentu</td>
			<td><input type="radio" id="poor" name="gradeOfQuestion1" value="poor" v-model="poor1"></td>
			<td><input v-model="fair1" type="radio" id="fair" name="gradeOfQuestion1" value="fair"></td>
			<td><input v-model="good1" type="radio" id="good" name="gradeOfQuestion1" value="good"></td>
			<td><input v-model="veryGood1" type="radio" id="veryGood" name="gradeOfQuestion1" value="veryGood"></td>
			<td><input v-model="excellent1" type="radio" id="excellent" name="gradeOfQuestion1" value="excellent"></td>
			</tr>
			<tr>
			<td v-model="textOfQuestion2">Posvećenost doktora pacijentu</td>
			<td><input v-model="poor2" type="radio" id="poor" name="gradeOfQuestion2" value="poor"></td>
			<td><input v-model="fair2" type="radio" id="fair" name="gradeOfQuestion2" value="fair"></td>
			<td><input v-model="good2" type="radio" id="good" name="gradeOfQuestion2" value="good"></td>
			<td><input v-model="veryGood2" type="radio" id="veryGood" name="gradeOfQuestion2" value="veryGood"></td>
			<td><input v-model="excellent2" type="radio" id="excellent" name="gradeOfQuestion2" value="excellent"></td>
			</tr>
			<tr>
			<td v-model="textOfQuestion3">Pružanje informacija od strane doktora o mom zdravstvenom stanju i mogućnostima lečenja</td>
			<td><input v-model="poor3" type="radio" id="poor" name="gradeOfQuestion3" value="poor"></td>
			<td><input v-model="fair3" type="radio" id="fair" name="gradeOfQuestion3" value="fair"></td>
			<td><input v-model="good3" type="radio" id="good" name="gradeOfQuestion3" value="good"></td>
			<td><input v-model="veryGood3" type="radio" id="veryGood" name="gradeOfQuestion3" value="veryGood"></td>
			<td><input v-model="excellent3" type="radio" id="excellent" name="gradeOfQuestion3" value="excellent"></td>
			</tr>
		</table> 
		<h3 class = "medicalstaff-qestions-title">Pitanja o medicinskom osoblju bolnice:</h3> 
		<table class="questions-about-medicalstaff">
			<tr>
			<th style="min-width:530px;">Pitanja</th>
			<th style="min-width:90px;">Vrlo loše</th>
			<th style="min-width:90px;">Loše</th>
			<th style="min-width:90px;">Dobro</th>
			<th style="min-width:90px;">Vrlo dobro</th>
			<th style="min-width:90px;">Odlično</th>
			</tr>
			<tr>
			<td v-model="textOfQuestion4">Ljubaznost medicinskog osoblja prema pacijentu</td>
			<td><input v-model="poor4" type="radio" id="poor" name="gradeOfQuestion4" value="poor"></td>
			<td><input v-model="fair4" type="radio" id="fair" name="gradeOfQuestion4" value="fair"></td>
			<td><input v-model="good4" type="radio" id="good" name="gradeOfQuestion4" value="good"></td>
			<td><input v-model="veryGood4" type="radio" id="veryGood" name="gradeOfQuestion4" value="veryGood"></td>
			<td><input v-model="excellent4" type="radio" id="excellent" name="gradeOfQuestion4" value="excellent"></td>
			</tr>
			<tr>
			<td v-model="textOfQuestion5">Posvećenost medicinskog osoblja pacijentu</td>
			<td><input v-model="poor5" type="radio" id="poor" name="gradeOfQuestion5" value="poor"></td>
			<td><input v-model="fair5" type="radio" id="fair" name="gradeOfQuestion5" value="fair"></td>
			<td><input v-model="good5" type="radio" id="good" name="gradeOfQuestion5" value="good"></td>
			<td><input v-model="veryGood5" type="radio" id="veryGood" name="gradeOfQuestion5" value="veryGood"></td>
			<td><input v-model="excellent5" type="radio" id="excellent" name="gradeOfQuestion5" value="excellent"></td>
			</tr>
			<tr>
			<td v-model="textOfQuestion6">Profesionalizam u obavljanju svoji duznosti medicinskog osoblja</td>
			<td><input v-model="poor6" type="radio" id="poor" name="gradeOfQuestion6" value="poor"></td>
			<td><input v-model="fair6" type="radio" id="fair" name="gradeOfQuestion6" value="fair"></td>
			<td><input v-model="good6" type="radio" id="good" name="gradeOfQuestion6" value="good"></td>
			<td><input v-model="veryGood6" type="radio" id="veryGood" name="gradeOfQuestion6" value="veryGood"></td>
			<td><input v-model="excellent6" type="radio" id="excellent" name="gradeOfQuestion6" value="excellent"></td>
			</tr>
		</table> 
		<h3 class = "hospital-qestions-title">Pitanja o radu bolnice:</h3> 
		<table class="questions-about-hospital">
			<tr>
			<th style="min-width:530px;">Pitanja</th>
			<th style="min-width:90px;">Vrlo loše</th>
			<th style="min-width:90px;">Loše</th>
			<th style="min-width:90px;">Dobro</th>
			<th style="min-width:90px;">Vrlo dobro</th>
			<th style="min-width:90px;">Odlično</th>
			</tr>
			<tr>
			<td v-model="textOfQuestion7">Ispunjenost vremena zakazanog termina i vreme provedeno u cekonici</td>
			<td><input v-model="poor7" type="radio" id="poor" name="gradeOfQuestion7" value="poor"></td>
			<td><input v-model="fair7" type="radio" id="fair" name="gradeOfQuestion7" value="fair"></td>
			<td><input v-model="good7" type="radio" id="good" name="gradeOfQuestion7" value="good"></td>
			<td><input v-model="veryGood7" type="radio" id="veryGood" name="gradeOfQuestion7" value="veryGood"></td>
			<td><input v-model="excellent7" type="radio" id="excellent" name="gradeOfQuestion7" value="excellent"></td>
			</tr>
			<tr>
			<td v-model="textOfQuestion8">Higijena unutar bolnice</td>
			<td><input v-model="poor8" type="radio" id="poor" name="gradeOfQuestion8" value="poor"></td>
			<td><input v-model="fair8" type="radio" id="fair" name="gradeOfQuestion8" value="fair"></td>
			<td><input v-model="good8" type="radio" id="good" name="gradeOfQuestion8" value="good"></td>
			<td><input v-model="veryGood8" type="radio" id="veryGood" name="gradeOfQuestion8" value="veryGood"></td>
			<td><input v-model="excellent8" type="radio" id="excellent" name="gradeOfQuestion8" value="excellent"></td>
			</tr>
			<tr>
			<td v-model="textOfQuestion9">Opremljenost bolnice</td>
			<td><input v-model="poor9" type="radio" id="poor" name="gradeOfQuestion9" value="poor"></td>
			<td><input v-model="fair9" type="radio" id="fair" name="gradeOfQuestion9" value="fair"></td>
			<td><input v-model="good9" type="radio" id="good" name="gradeOfQuestion9" value="good"></td>
			<td><input v-model="veryGood9" type="radio" id="veryGood" name="gradeOfQuestion9" value="veryGood"></td>
			<td><input v-model="excellent9" type="radio" id="excellent" name="gradeOfQuestion9" value="excellent"></td>
			</tr>
		</table> 
		<h3 class = "survey-comment-title">Komentar:</h3> 
		<textarea v-model="commentSurvey" class = "survey-comment" placeholder="Prostor za dodatni komentar..." rows="9" cols="92" style="resize: none;"></textarea>

		<div class="survey-comment-btn">
			<button type="button" @click="postSurvey">Pošalji</button>
		</div>

	</div>
	
	 
	 

	     
	</div>	  
	</div>
        
	`
	,
	methods: {
		postSurvey: function () {

			if (this.poor1 == "poor") {
				this.gradeOfQuestion1 = 0;
			} else if(this.fair1 == "fair"){
				this.gradeOfQuestion1 = 1;
			} else if (this.good1 == "good") {
				this.gradeOfQuestion1 = 2;
			} else if (this.veryGood1 == "veryGood") {
				this.gradeOfQuestion1 = 3;
			} else if (this.excellent1 == "excellent") {
				this.gradeOfQuestion1 = 4;
			}

			var question1={
				questionText: 'Ljubaznost doktora prema pacijentu',
				answer: this.gradeOfQuestion1
			}

			if (this.poor2 == "poor") {
				this.gradeOfQuestion2 = 0;
			} else if (this.fair2 == "fair") {
				this.gradeOfQuestion2 = 1;
			} else if (this.good2 == "good") {
				this.gradeOfQuestion2 = 2;
			} else if (this.veryGood2 == "veryGood") {
				this.gradeOfQuestion2 = 3;
			} else if (this.excellent2 == "excellent") {
				this.gradeOfQuestion2 = 4;
			}

			var question2 = {
				questionText: 'Posvećenost doktora pacijentu',
				answer: this.gradeOfQuestion2
			}

			if (this.poor3 == "poor") {
				this.gradeOfQuestion3 = 0;
			} else if (this.fair3 == "fair") {
				this.gradeOfQuestion3 = 1;
			} else if (this.good3 == "good") {
				this.gradeOfQuestion3 = 2;
			} else if (this.veryGood3 == "veryGood") {
				this.gradeOfQuestion3 = 3;
			} else if (this.excellent3 == "excellent") {
				this.gradeOfQuestion3 = 4;
			}

			var question3 = {
				questionText: 'Pružanje informacija od strane doktora o mom zdravstvenom stanju i mogućnostima lečenja',
				answer: this.gradeOfQuestion3
			}

			if (this.poor4 == "poor") {
				this.gradeOfQuestion4 = 0;
			} else if (this.fair4 == "fair") {
				this.gradeOfQuestion4 = 1;
			} else if (this.good4 == "good") {
				this.gradeOfQuestion4 = 2;
			} else if (this.veryGood4 == "veryGood") {
				this.gradeOfQuestion4 = 3;
			} else if (this.excellent4 == "excellent") {
				this.gradeOfQuestion4 = 4;
			}

			var question4 = {
				questionText: 'Ljubaznost medicinskog osoblja prema pacijentu',
				answer: this.gradeOfQuestion4
			}

			if (this.poor5 == "poor") {
				this.gradeOfQuestion5 = 0;
			} else if (this.fair5 == "fair") {
				this.gradeOfQuestion5 = 1;
			} else if (this.good5 == "good") {
				this.gradeOfQuestion5 = 2;
			} else if (this.veryGood5 == "veryGood") {
				this.gradeOfQuestion5 = 3;
			} else if (this.excellent5 == "excellent") {
				this.gradeOfQuestion5 = 4;
			}

			var question5 = {
				questionText: 'Posvećenost medicinskog osoblja pacijentu',
				answer: this.gradeOfQuestion5
			}

			if (this.poor6 == "poor") {
				this.gradeOfQuestion6 = 0;
			} else if (this.fair6 == "fair") {
				this.gradeOfQuestion6 = 1;
			} else if (this.good6 == "good") {
				this.gradeOfQuestion6 = 2;
			} else if (this.veryGood6 == "veryGood") {
				this.gradeOfQuestion6 = 3;
			} else if (this.excellent6 == "excellent") {
				this.gradeOfQuestion6 = 4;
			}

			var question6 = {
				questionText: 'Profesionalizam u obavljanju svoji duznosti medicinskog osoblja',
				answer: this.gradeOfQuestion6
			}

			if (this.poor7 == "poor") {
				this.gradeOfQuestion7 = 0;
			} else if (this.fair7 == "fair") {
				this.gradeOfQuestion7 = 1;
			} else if (this.good7 == "good") {
				this.gradeOfQuestion7 = 2;
			} else if (this.veryGood7 == "veryGood") {
				this.gradeOfQuestion7 = 3;
			} else if (this.excellent7 == "excellent") {
				this.gradeOfQuestion7 = 4;
			}

			var question7 = {
				questionText: 'Ispunjenost vremena zakazanog termina i vreme provedeno u cekonici',
				answer: this.gradeOfQuestion7
			}

			if (this.poor8 == "poor") {
				this.gradeOfQuestion8 = 0;
			} else if (this.fair8 == "fair") {
				this.gradeOfQuestion8 = 1;
			} else if (this.good8 == "good") {
				this.gradeOfQuestion8 = 2;
			} else if (this.veryGood8 == "veryGood") {
				this.gradeOfQuestion8 = 3;
			} else if (this.excellent8 == "excellent") {
				this.gradeOfQuestion8 = 4;
			}

			var question8 = {
				questionText: 'Higijena unutar bolnice',
				answer: this.gradeOfQuestion8
			}

			if (this.poor9 == "poor") {
				this.gradeOfQuestion9 = 0;
			} else if (this.fair9 == "fair") {
				this.gradeOfQuestion9 = 1;
			} else if (this.good9 == "good") {
				this.gradeOfQuestion9 = 2;
			} else if (this.veryGood9 == "veryGood") {
				this.gradeOfQuestion9 = 3;
			} else if (this.excellent9 == "excellent") {
				this.gradeOfQuestion9 = 4;
			}

			var question9 = {
				questionText: 'Opremljenost bolnice',
				answer: this.gradeOfQuestion9
			}

			this.listOfQuestions.push(question1)
			this.listOfQuestions.push(question2)
			this.listOfQuestions.push(question3)
			this.listOfQuestions.push(question4)
			this.listOfQuestions.push(question5)
			this.listOfQuestions.push(question6)
			this.listOfQuestions.push(question7)
			this.listOfQuestions.push(question8)
			this.listOfQuestions.push(question9)


			var formatted_date = new Date().toJSON().slice(0, 10).replace(/-/g, '/');
			//"2020-11-06T08:30:00"

			axios.post('/api/survey', {
				title: 'Naslov ankete',
				commentSurvey: this.commentSurvey,
				questions: this.listOfQuestions
			});
				
		}

	},
	computed: {

	},
	mounted() {



	}

});