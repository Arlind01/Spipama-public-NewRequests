export interface IIndicatorStrategic {
  id: string;
  objectiveStrategicId: string;
  identifier: number;
  name: string;
  base: string;
  inputType?: number;
  indicatorTemp: number;
  indicatorTempAchieved: number;
  indicatorFinal: number;
  indicatorFinalAchieved: number;
  result: string;
  indicatorStatusId: number;
  isDeleted?: boolean;
  responsibleInstitutionId: string;
}
