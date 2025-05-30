export interface Activity {
  id: number;
  name: string;
  description?: string;
}

export class ActivityApi {
  private static readonly API_BASE_URL = 'http://localhost:5133/api/activity';

  static async getAll(): Promise<Activity[]> {
    try {
      const response = await fetch(`${this.API_BASE_URL}/getAll`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (!response.ok) {
        const errorData = await response.json();
        throw new Error(errorData.error || `HTTP error! status: ${response.status}`);
      }

      return await response.json();
    } catch (error) {
      console.error('Error fetching activities:', error);
      throw error;
    }
  }

  static async Delete(id: string) {
    let response = await fetch(this.API_BASE_URL + "/" + id, {
      method: 'DELETE',
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json'
      }
    });

    if (!response.ok) {
      let message = 'could not delete activity: ' + response.status;
      return message;
    }

    return response.status;
  }
}