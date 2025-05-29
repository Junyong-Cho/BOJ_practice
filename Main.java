import java.io.IOException;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.StringTokenizer;
import java.util.Arrays;

public class Main {
	
	static BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
	static StringTokenizer st;
	static int ans, k, max;
	static char num[], temp[];
	
	static public void main(String catchsunpie[]) throws IOException{
		st = new StringTokenizer(br.readLine());
		
		num = st.nextToken().toCharArray();
		temp = num.clone();
		
		Arrays.sort(temp);
		
		max = 0;
		
		for(int i = temp.length-1; i >= 0; i--)
			max = (max<<3) + (max<<1) + (temp[i]&0b1111);
		
		k = Integer.parseInt(st.nextToken());
		
		boolean check = true;
		for(int i = 1; i < num.length; i++) {
			check = num[i]=='0'&&check;
		}
		
		if(num.length==1||check) {
			System.out.println(-1);
			return;
		}
		
		tracking(0);
		
		System.out.println(ans);
	}
	
	static void tracking(int count) {
		if(count==k) {
			ans = max(ans,toInt());
			if(max==ans) {
				System.out.println(ans);
				System.exit(0);
			}
			return;
		}
		
		for(int i = 0; i < num.length-1; i++)
			for(int j = i+1; j < num.length; j++) {
				swap(i,j);
				tracking(count+1);
				swap(i,j);
			}
	}
	
	static int toInt() {
		int n = num[0]&0b1111;
		
		for(int i = 1; i < num.length; i++)
			n = (n<<3) + (n<<1) + (num[i]&0b1111);
		
		return n;
	}
	
	static void swap(int i, int j) {
		char c = num[i];
		num[i] = num[j];
		num[j] = c;
	}
	
	static int max(int i, int j) {
		return i>j?i:j;
	}
}
