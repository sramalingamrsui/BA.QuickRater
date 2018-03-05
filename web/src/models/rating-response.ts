export interface ApiResult {
    successResult: boolean,
    warnings: string[]
    errors: string[]
}

export interface Location {
    premisesNumber: number,
    zipCode: number,
    city: string,
    state: string
}

export interface Rates {
    premisesUnmodifiedIncreasedLimitsFactor: number,
    premisesIncreasedLimitsFactor: number,
    premisesLossCostModifier: number,
    premisesUnmodifiedRate: number,
    premisesRate: number,
    isPremisesRateEditable: boolean,
    productsUnmodifiedIncreasedLimitsFactor: number,
    productsIncreasedLimitsFactor: number,
    productsLossCostModifier: number,
    productsUnmodifiedRate: number,
    productsRate: number,
    isProductsRateEditable: boolean,
    isProductsIncluded: boolean,
    additionalModifier: number,
    companyLossCostMultiplier: number,
    isPremisesARated: boolean,
    isProductsARated: boolean
}

export interface Exposure {
    exposureDataType: string,
    exposureDivisor: number,
    exposureBasis: string,
    question: string,
    questionID: number
}

export interface RateInfo {
    rates: Rates,
    exposure: Exposure
}

export interface ClasscodeRateInfo {
    rateInfo: RateInfo
}

export interface ClasscodeRate {
    premisesRef: number,
    number: number,
    subcode: number,
    description: string,
    classCodeRateInfo: ClasscodeRateInfo
}

export interface GLCoverage {
    aggregateOccurrenceLimits: string,
    classCodeSchedule: ClasscodeRate[]
}

export interface RatingResponse {
    apiResult: ApiResult,
    effectiveDate: Date,
    expirationDate: Date,
    locationSchedule: Location[],
    glCoverage: GLCoverage
}